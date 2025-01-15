using Application.IRepository;
using Application.IService;
using Application.Models;
using Application.Models.InventoryModels;
using Application.Models.JewelryModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utilities;
using static Utilities.Enum;

namespace Infrastructure.Service
{
    public class InventoryService : BaseDomainService<Inventory, InventorySearch>, IInventoryService
    {
        private readonly IJewelryService _jewelryService;
        private readonly IInventoryDetailsService _inventoryDetailsService;
        public InventoryService(IJewelryService jewelryService, IInventoryDetailsService inventoryDetailsService, IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _jewelryService = jewelryService;
            _inventoryDetailsService = inventoryDetailsService;
        }

        public async Task<PagedList<InventoryModel>> GetPagedListInventories(InventorySearch inventorySearch)
        {
            PagedList<Inventory> pagedList = await GetPagedListData(inventorySearch);
            PagedList<InventoryModel> pagedListModel = _mapper.Map<PagedList<InventoryModel>>(pagedList);
            return pagedListModel;
        }

        protected override string GetStoreProcName()
        {
            return "GetPagedData_Innventory";
        }

        public async Task<InventoryModel> GetInventoryByIdAsync(Guid inventoryId)
        {
            // Lấy dữ liệu từ các repository
            IQueryable<Inventory> inventoryQuery = _unitOfWork
                .Repository<Inventory>()
                .GetQueryable()
                .AsQueryable();

            IQueryable<InventoryDetails> detailsQuery = _unitOfWork
                .Repository<InventoryDetails>()
                .GetQueryable()
                .AsQueryable();

            IQueryable<Jewelry> jewelryQuery = _unitOfWork
                .Repository<Jewelry>()
                .GetQueryable()
                .AsQueryable();

            // Thực hiện JOIN các bảng
            var inventoryWithDetails = from inventory in inventoryQuery
                                       where inventory.Id == inventoryId && inventory.Deleted == false
                                       join detail in detailsQuery on inventory.Id equals detail.InventoryId
                                       join jewelry in jewelryQuery on detail.JewelryId equals jewelry.Id
                                       select new
                                       {
                                           Inventory = inventory,
                                           //Detail = detail,
                                           Jewelry = jewelry
                                       };

            // Lấy dữ liệu từ DB //Tải toàn bộ từ dữ liệu => Có thể gây tiêu tốn bộ nhớ 
            var groupedData = await inventoryWithDetails.ToListAsync();

            var inventoryData = groupedData
                .Select(x => x.Inventory)
                .FirstOrDefault();

            // Xử lý dữ liệu trả về
            InventoryModel model = _mapper.Map<InventoryModel>(inventoryData);

            if (inventoryData != null)
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
                throw new KeyNotFoundException($"Inventory with ID '{inventoryId}' does not exist!");
            }
        }

        //Cách này dùng khi có ít dữ liệu : vài trăm rows
        //Inventory inventory = await Queryable //AsNoTracking(): không theo dõi entity trong DbContext
        //    .Include(id => id.InventoryDetails)      // deferred execution - Query sẽ được dịch thành SQL
        //        .ThenInclude(j => j.Jewelry)         // Include giống join, làm chậm nếu nhiều data
        //    .Where(x => x.Deleted == false && x.Id == inventoryId)
        //    .FirstOrDefaultAsync();

        //Cách này trung bình
        //var inventory = await Queryable
        //    .Where(x => x.Deleted == false && x.Id == inventoryId)
        //    .ProjectTo<InventoryModel>(_mapper.ConfigurationProvider)
        //    .FirstOrDefaultAsync();

        public async Task CreateImportInventoryAsync(InventoryImportCreate inventoryImportCreate)
        {
            if (inventoryImportCreate.InventoryDetailsImportCreates == null)
            {
                throw new AppException("Inventory details import creates cannot be null!");
            }

            Inventory inventory = _mapper.Map<Inventory>(inventoryImportCreate);
            inventory.Id = Guid.NewGuid();
            inventory.Type = (int)InventoryTypeEnum.Import;
            inventory.Status = (int)InventoryEnum.Temporary;
            inventory.Code = CodeGenerator.GenerateCode("IMPORT", 4);

            List<InventoryDetails> inventoryDetails = _mapper.Map<List<InventoryDetails>>
                                        (inventoryImportCreate.InventoryDetailsImportCreates);

            inventoryDetails.ToList().ForEach(x =>
            {
                x.InventoryId = inventory.Id;
            });

            IList<Jewelry> jewelries = await _jewelryService
                .GetListAsync(x => x.Deleted == false // Danh sách Jewlry chưa Deleted
                        && inventoryDetails
                            .Select(j => j.JewelryId) // Lấy List JewelryId từ inventoryDetails
                            .Contains(x.Id)); // Kiểm tra Id của Jewelry hiện tại(x.Id) có được
                                              // lấy ra từ list JewelryId trong inventoryDetails

            if (jewelries.Any(j => j.Status != (int)JewelryStatus.Approved))
            {
                throw new AppException($"All jewelries must have status '{JewelryStatus.Approved.ToString()}'.");
            }

            inventory.TotalImportPrice = inventoryImportCreate
                .InventoryDetailsImportCreates.Sum(x => x.ImportPrice);

            jewelries
                .ToList()
                .ForEach(j =>
                {
                    // Tìm inventory details có chứa JewleyId = Id nằm trong jewelries
                    var detail = inventoryDetails.FirstOrDefault(d => d.JewelryId == j.Id);
                    if (detail != null)
                    {
                        j.ImportPrice = detail.ImportPrice;
                        j.Status = (int)JewelryStatus.AwaitingStockIn;
                        j.Updated = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
                    }
                });
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await CreateAsync(inventory);
                await _jewelryService.UpdateAsync(jewelries);
                await _inventoryDetailsService.CreateAsync(inventoryDetails);

                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw new AppException("An error occurred while adding new inventory! " + ex.Message);
            }
        }

        public async Task ProcessImportInventory(InventoryImportProcessApproval model)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                Inventory inventory = await GetByIdAsync(model.Id);
                if (inventory == null)
                {
                    throw new KeyNotFoundException($"Inventory with ID '{model.Id}' does not exist!");
                }

                if (inventory.Status != (int)InventoryEnum.Temporary)
                {
                    throw new AppException($"Inventory must have status {InventoryEnum.Temporary.ToString()} to update!");
                }

                // Lấy danh sách Jewelry trong Inventory
                var inventoryJewelryIds = _unitOfWork.Repository<InventoryDetails>()
                    .GetQueryable()
                    .Where(id => id.InventoryId == inventory.Id && id.Deleted == false)
                    .Select(id => id.JewelryId)
                    .ToList();

                // Lấy danh sách Jewelry từ model
                var modelJewelryIds = model.JewelrySellPriceProcess
                    .Select(j => j.JewelryId)
                    .ToList();

                // So sánh hai danh sách
                bool isMatching = !inventoryJewelryIds.Except(modelJewelryIds).Any()
                                && !modelJewelryIds.Except(inventoryJewelryIds).Any();

                if (!isMatching)
                {
                    throw new AppException("The list of jewelry in the model does not match the inventory!");
                }

                if (model.JewelrySellPriceProcess == null)
                {
                    throw new AppException("Inventory must contain Jewelries for process");
                }

                if (model.Status != (int)InventoryEnum.Approved
                    && model.Status != (int)InventoryEnum.NotApproved)
                {
                    throw new AppException($"Inventory is not in a valid status for update");
                }

                // Cập nhật Approved
                if (model.Status == (int)InventoryEnum.Approved)
                {
                    inventory.Status = (int)InventoryEnum.Approved;
                    inventory.ImportedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
                    IList<Jewelry> jewelries = await _jewelryService
                        .GetListAsync(x => x.Deleted == false
                            && model.JewelrySellPriceProcess
                            .Select(j => j.JewelryId)
                            .Contains(x.Id));

                    jewelries
                        .ToList()
                        .ForEach(x =>
                        {
                            var jewelry = model.JewelrySellPriceProcess
                                .FirstOrDefault(w => w.JewelryId == x.Id);
                            if (jewelry != null)
                            {
                                x.Status = (int)JewelryStatus.AvailableForSale;
                                x.SalePrice = jewelry.SalePrice;
                                x.Updated = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
                                x.ImportedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
                            }
                        });
                    await _jewelryService.UpdateAsync(jewelries);
                }

                // Cập nhật NotApproved
                if (model.Status == (int)InventoryEnum.NotApproved)
                {
                    inventory.Status = (int)InventoryEnum.NotApproved;
                    IList<Jewelry> jewelries = await _jewelryService
                        .GetListAsync(x => x.Deleted == false
                            && model.JewelrySellPriceProcess
                            .Select(j => j.JewelryId)
                            .Contains(x.Id));

                    jewelries
                        .ToList()
                        .ForEach(x =>
                        {
                            var jewelry = model.JewelrySellPriceProcess
                                .FirstOrDefault(w => w.JewelryId == x.Id);
                            if (jewelry != null)
                            {
                                x.Status = (int)JewelryStatus.Cancelled;
                                x.SalePrice = jewelry.SalePrice;
                                x.Updated = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
                            }
                        });
                    await _jewelryService.UpdateAsync(jewelries);
                }

                inventory.Updated = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
                inventory.Note = model.Note;

                await UpdateAsync(inventory);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw new AppException("An error occurred while process inventory! " + ex.Message);
            }
        }

        public Task CreateExportInventoryAsync(InventoryExportCreate inventoryExportCreate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInventoryAsync(InventoryUpdate inventoryUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteInventoryAsync(Guid id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                //Cập nhật Inventory
                Inventory inventory = await GetByIdAsync(id);
                if (inventory == null)
                {
                    throw new KeyNotFoundException($"Inventory with ID '{id}' does not exist!");
                }

                if (inventory.Status != (int)InventoryEnum.Temporary)
                {
                    throw new AppException("Only temporarty inventory can be deleted");
                }
                inventory.Deleted = true;
                inventory.Updated = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));

                //Cập nhật Inventory Detail
                var inventoryDetails = _unitOfWork
                    .Repository<InventoryDetails>()
                    .GetQueryable()
                    .AsNoTracking()
                    .Where(invdetail => invdetail.InventoryId == inventory.Id && invdetail.Deleted == false)
                    .ToList();

                inventoryDetails.ForEach(x =>
                {
                    x.Deleted = true;
                    x.Updated = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
                });

                //Cập nhật Jewelry
                var inventoryJewelryIds = inventoryDetails
                    .Select(x => x.JewelryId)
                    .ToList();

                IList<Jewelry> jewelries = await _jewelryService
                    .GetListAsync(x => x.Deleted == false && inventoryJewelryIds.Contains(x.Id));
                jewelries.ToList().ForEach(x =>
                {
                    x.Status = (int)JewelryStatus.Approved;
                });

                await UpdateAsync(inventory);
                await _inventoryDetailsService.UpdateFieldAsync(inventoryDetails.ToList(),
                        x => x.Deleted,
                        x => x.Updated);
                await _jewelryService.UpdateFieldAsync(jewelries.ToList(), x => x.Status);

                //Lưu thay đổi
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw new AppException("An error occurred while deleted inventory! " + ex.Message);
            }
        }
    }
}
