using Application.IRepository;
using Application.IService;
using Application.Models.JewelryModels;
using Application.Models.OrderModels;
using AutoMapper;
using Domain.Entities;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using static Utilities.Enum;

namespace Infrastructure.Service
{
    public class OrderService : BaseDomainService<Order, OrderSearch>, IOrderService
    {
        private readonly IJewelryService _jewelryService;
        public OrderService(IAppUnitOfWork unitOfWork, IMapper mapper,
            IJewelryService jewelryService
            ) : base(unitOfWork, mapper)
        {
            _jewelryService = jewelryService;
        }
        public async Task<PagedList<OrderModel>> GetPagedListOrderAsync(OrderSearch orderSearch)
        {
            PagedList<Order> orderList = await GetPagedListData(orderSearch);
            PagedList<OrderModel> orderModelList = _mapper.Map<PagedList<OrderModel>>(orderList);
            return orderModelList;
        }

        protected override string GetStoreProcName()
        {
            return "GetPagedData_Order";
        }

        public async Task<OrderModel> GetOrderByIdAsync(Guid id)
        {
            IQueryable<Order> orderQuery = _unitOfWork
                .Repository<Order>()
                .GetQueryable()
                .AsQueryable();

            IQueryable<OrderDetail> orderDetailsQuery = _unitOfWork
                .Repository<OrderDetail>()
                .GetQueryable()
                .AsQueryable();

            IQueryable<Jewelry> jewelriesQuery = _unitOfWork
                .Repository<Jewelry>()
                .GetQueryable()
                .AsQueryable();

            IQueryable<User> usersQuery = _unitOfWork
                .Repository<User>()
                .GetQueryable()
                .AsQueryable();

            var orderWithDetails = from order in orderQuery
                                   where order.Id == id && order.Deleted == false
                                   join detail in orderDetailsQuery on order.Id equals detail.OrderId
                                   where detail.Deleted == false
                                   join jewelry in jewelriesQuery on detail.JewelryId equals jewelry.Id
                                   where jewelry.Deleted == false
                                   join user in usersQuery on order.CustomerId equals user.Id
                                   where user.Deleted == false
                                   select new
                                   {
                                       Order = order,
                                       Jewelry = jewelry,
                                       User = user,
                                   };

            var groupedData = await orderWithDetails.ToListAsync();

            var orderData = groupedData.Select(x => x.Order).FirstOrDefault();
            var userData = groupedData.Select(x => x.User).FirstOrDefault();

            OrderModel model = _mapper.Map<OrderModel>(orderData);
            model.CustomerName = userData.UserName;

            if (orderData != null)
            {
                var jewelryInfor = groupedData
                    .Where(x => /*x.Detail != null &&*/ x.Jewelry != null) // Chỉ lấy bản ghi có Detail
                    .Select(d => new Jewelry
                    {
                        Id = d.Jewelry.Id,
                        Name = d.Jewelry.Name,
                        Code = d.Jewelry.Code,
                        Description = d.Jewelry.Description,
                        CreatedPrice = d.Jewelry.CreatedPrice,
                        ImportPrice = d.Jewelry.ImportPrice,
                        SalePrice = d.Jewelry.SalePrice,
                        Status = d.Jewelry.Status,
                        ImportedAt = d.Jewelry.ImportedAt,
                        SoldAt = d.Jewelry.SoldAt,
                        Note = d.Jewelry.Note,
                        ImageUrl = d.Jewelry.ImageUrl,
                        Origin = d.Jewelry.Origin,
                        Supplier = d.Jewelry.Supplier,
                    })
                    .ToList();
                model.JewelryModels = _mapper.Map<List<JewelryModel>>(jewelryInfor);
                return model;
            }
            else
            {
                throw new KeyNotFoundException($"Order with ID '{id}' does not exist!");
            }
        }

        public async Task CreateOrderAsync(OrderCreate orderCreate)
        {
            try
            {
                Order order = _mapper.Map<Order>(orderCreate);
                order.Id = Guid.NewGuid();
                order.Code = CodeGenerator.GenerateCode("ORDER", 6);
                order.Status = (int)OrderStatus.Processing;

                IList<Jewelry> jewelries = await _jewelryService
                    .GetListAsync(x => x.Deleted == false
                        && x.Status == (int)JewelryStatus.AvailableForSale
                        && orderCreate.JewelryIds.Select(j => j).Contains(x.Id));

                if (jewelries.Any(j => j.Status != (int)JewelryStatus.AvailableForSale))
                {
                    throw new AppException($"All jewelries must have status '{JewelryStatus.AvailableForSale.ToString()}'.");
                }
                order.TotalAmount = (decimal)jewelries.Sum(x => x.SalePrice);

                jewelries
                    .ToList()
                    .ForEach(j =>
                    {
                        j.Status = (int)JewelryStatus.Sold;
                        j.Updated = DateTimeUtil.GetCurrentTime();

                        var orderDetail = new OrderDetail
                        {
                            OrderId = order.Id,
                            JewelryId = j.Id,
                            SalePrice = (decimal)j.SalePrice,
                            SoldAt = DateTimeUtil.GetCurrentTime(),
                        };

                        order.OrderDetails ??= new List<OrderDetail>();
                        order.OrderDetails.Add(orderDetail);
                    });

                await CreateAsync(order);
                await _jewelryService.UpdateAsync(jewelries);

                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw new AppException("An error occurred while adding new order " + ex.Message);
            }
        }

        public async Task UpdateOrderAsync(OrderUpdate orderUpdate)
        {
            try
            {
                var existingOrder = await GetByIdAsync(orderUpdate.Id);
                if (existingOrder == null)
                {
                    throw new AppException("Order not found.");
                }

                if (existingOrder.Status != (int)OrderStatus.Processing)
                {
                    throw new AppException("Only processing orders can be updated.");
                }

                bool isModified = false; 

                if (orderUpdate.CustomerId.HasValue && orderUpdate.CustomerId.Value != existingOrder.CustomerId)
                {
                    existingOrder.CustomerId = orderUpdate.CustomerId.Value;
                    isModified = true;
                }

                if (!string.IsNullOrEmpty(orderUpdate.Note) && orderUpdate.Note != existingOrder.Note)
                {
                    existingOrder.Note = orderUpdate.Note;
                    isModified = true;
                }

                if (orderUpdate.Status.HasValue && orderUpdate.Status.Value != existingOrder.Status)
                {
                    existingOrder.Status = orderUpdate.Status.Value;
                    isModified = true;
                }

                if (orderUpdate.JewelryIds != null && !orderUpdate.JewelryIds.SequenceEqual(existingOrder.OrderDetails.Select(od => od.JewelryId)))
                {
                    foreach (var detail in existingOrder.OrderDetails)
                    {
                        var oldJewelry = await _jewelryService.GetByIdAsync(detail.JewelryId);
                        if (oldJewelry != null)
                        {
                            oldJewelry.Status = (int)JewelryStatus.AvailableForSale;
                            oldJewelry.Updated = DateTimeUtil.GetCurrentTime();
                        }
                    }

                    // Lấy danh sách trang sức mới
                    IList<Jewelry> jewelries = await _jewelryService
                        .GetListAsync(x => x.Deleted == false
                            && x.Status == (int)JewelryStatus.AvailableForSale
                            && orderUpdate.JewelryIds.Contains(x.Id));

                    if (jewelries.Any(j => j.Status != (int)JewelryStatus.AvailableForSale))
                    {
                        throw new AppException($"All jewelries must have status '{JewelryStatus.AvailableForSale.ToString()}' to be added to the order.");
                    }

                    // Xóa danh sách cũ và thêm danh sách mới
                    existingOrder.OrderDetails.Clear();
                    jewelries.ToList().ForEach(j =>
                    {
                        j.Status = (int)JewelryStatus.Sold;
                        j.Updated = DateTimeUtil.GetCurrentTime();

                        var orderDetail = new OrderDetail
                        {
                            OrderId = existingOrder.Id,
                            JewelryId = j.Id,
                            SalePrice = (decimal)j.SalePrice,
                            SoldAt = DateTimeUtil.GetCurrentTime(),
                        };

                        existingOrder.OrderDetails.Add(orderDetail);
                    });

                    // Cập nhật tổng tiền đơn hàng
                    existingOrder.TotalAmount = (decimal)jewelries.Sum(x => x.SalePrice);
                    isModified = true;

                    // Cập nhật trạng thái trang sức mới
                    await _jewelryService.UpdateAsync(jewelries);
                }

                if (isModified)
                {
                    existingOrder.Updated = DateTimeUtil.GetCurrentTime();
                    await UpdateAsync(existingOrder);
                    await _unitOfWork.SaveAsync();
                    await _unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw new AppException("An error occurred while updating order " + ex.Message);
            }
        }
        public async Task DeleteOrderAsync(Guid id)
        {
            try
            {
                var existingOrder = await GetByIdAsync(id);
                if (existingOrder == null)
                {
                    throw new AppException("Order not found.");
                }

                // Kiểm tra trạng thái đơn hàng Processing
                if (existingOrder.Status != (int)OrderStatus.Processing)
                {
                    throw new AppException("Only processing orders can be deleted.");
                }

                // Khôi phục trạng thái trang sức về AvailableForSale
                foreach (var detail in existingOrder.OrderDetails)
                {
                    var jewelry = await _jewelryService.GetByIdAsync(detail.JewelryId);
                    if (jewelry != null)
                    {
                        jewelry.Status = (int)JewelryStatus.AvailableForSale;
                        jewelry.Updated = DateTimeUtil.GetCurrentTime();
                    }
                }
                // Cập nhật lại trạng thái trang sức
                var jewelryList = await _jewelryService.GetListAsync(x => existingOrder.OrderDetails.Select(d => d.JewelryId).Contains(x.Id));

                // Khôi phục trạng thái trang sức về "AvailableForSale"
                foreach (var jewelry in jewelryList)
                {
                    jewelry.Status = (int)JewelryStatus.AvailableForSale;
                    jewelry.Updated = DateTimeUtil.GetCurrentTime();
                }
                await _jewelryService.UpdateAsync(jewelryList);

                await DeleteAsync(existingOrder.Id);

                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw new AppException("An error occurred while deleting order " + ex.Message);
            }
        }

    }
}
