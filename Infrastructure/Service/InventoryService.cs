using Application.IRepository;
using Application.IService;
using Application.Models;
using Application.Models.InventoryModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
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

        public async Task<Inventory> GetInventoryByIdAsync(Guid inventoryId)
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
                                       join detail in detailsQuery on inventory.Id equals detail.InventoryId into detailGroup
                                       from detail in detailGroup.DefaultIfEmpty()
                                       join jewelry in jewelryQuery on detail.JewelryId equals jewelry.Id into jewelryGroup
                                       from jewelry in jewelryGroup.DefaultIfEmpty()
                                       select new
                                       {
                                           Inventory = inventory,
                                           Detail = detail,
                                           Jewelry = jewelry
                                       };

            // Lấy dữ liệu từ CSDL
            var groupedData = await inventoryWithDetails.ToListAsync();

            var inventoryData = groupedData
                .Select(x => x.Inventory)
                .FirstOrDefault();

            if (inventoryData != null)
            {
                var inventoryDetails = groupedData
                    .Where(x => x.Detail != null) // Chỉ lấy bản ghi có Detail
                    .Select(d => new InventoryDetails
                    {
                        Id = d.Detail.Id,
                        InventoryId = d.Detail.InventoryId,
                        JewelryId = d.Detail.JewelryId,
                        ImportPrice = d.Detail.ImportPrice,
                        ExportPrice = d.Detail.ExportPrice,
                        Jewelry = d.Jewelry
                    })
                    .ToList();

                inventoryData.InventoryDetails = inventoryDetails;

                return inventoryData;
            }
            else
            {
                throw new KeyNotFoundException($"Inventory with ID '{inventoryId}' does not exist!");
            }
        }

        //Cách này chậm
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
        //if (inventory != null)
        //{
        //    return inventory;
        //}
        //throw new KeyNotFoundException($"Inventory with ID '{id}' does not exist!");

        public Task CreateExportInventoryAsync(InventoryExportCreate inventoryExportCreate)
        {
            throw new NotImplementedException();
        }

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
            inventory.ImportedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));

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

            if (jewelries.Any(j => j.Status != (int)JewelryStatus.AwaitingStockIn))
            {
                throw new AppException($"All jewelries must have status '{JewelryStatus.AwaitingStockIn.ToString()}'.");
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

        public async Task ProcessInventory(InventoryImportProcessApproval model)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                Inventory inventory = await GetByIdAsync(model.Id);
                if (inventory == null)
                {
                    throw new KeyNotFoundException($"Inventory with ID '{model.Id}' does not exist!");
                }

                if (model.JewelrySellPriceProcess == null)
                {
                    throw new AppException("Inventory must contain Jewelries for process");
                }

                if (inventory.Status != (int)InventoryEnum.Temporary)
                {
                    throw new AppException($"Inventory must have status {InventoryEnum.Temporary.ToString()} to update!");
                }

                if (model.Status != (int)InventoryEnum.Approved
                    && model.Status != (int)InventoryEnum.NotApproved)
                {
                    throw new AppException($"Inventory is not in a valid status for update");
                }

                if (model.Status == (int)InventoryEnum.Approved)
                {
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
                            }
                        });
                    await _jewelryService.UpdateAsync(jewelries);
                }

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

        public Task UpdateInventoryAsync(InventoryUpdate inventoryUpdate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInventoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
