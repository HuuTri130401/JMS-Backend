using Application.IRepository;
using Application.IService;
using Application.Models.OrderModels;
using AutoMapper;
using Domain.Entities;
using MailKit.Search;
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
            Order order = await GetByIdAsync(id);
            if(order == null)
            {
                throw new KeyNotFoundException($"Order with ID '{id}' does not exist.");
            }
            OrderModel orderModel = _mapper.Map<OrderModel>(order); 
            return orderModel;
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

        public Task UpdateOrderAsync(OrderUpdate order)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            Order order = await GetByIdAsync(id);
            if(order == null)
            {
                throw new KeyNotFoundException($"Order with ID '{id}' dost not exist.");
            }

            //if (order.Status != (int)JewelryStatus.PendingApproval && order.Status != (int)JewelryStatus.Approved)
            //{
            //    throw new AppException($"You are only allowed to delete jewelry with the status " +
            //        $"'{JewelryStatus.PendingApproval.ToString()}' or '{JewelryStatus.Approved.ToString()}'");
            //}

            bool success = await DeleteAsync(id);
            if (!success)
            {
                throw new AppException("An error occurred while deleting the Order!");
            }
        }
    }
}
