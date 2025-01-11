using Application.IRepository;
using Application.IService;
using Application.Models.InventoryModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
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
            
            if(jewelries.Any(j => j.Status != (int)JewelryStatus.AwaitingStockIn))
            {
                throw new AppException("All jewelries must have status 'AwaitingStockIn'.");
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
            catch(Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw new AppException("An error occurred while adding new inventory! " + ex.Message);
            }

            //jewelries
            //    .Where(p =>
            //        p.Status == (int)JewelryStatus.PendingApproval ||
            //        p.Status == (int)JewelryStatus.AwaitingStockIn
            //    )
            //    .ToList()
            //    .ForEach(x => x.Status = (int)JewelryStatus.AwaitingStockIn);
        }

        public Task DeleteInventoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<InventoryModel> GetInventoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<InventoryModel>> GetPagedListInventories(InventorySearch inventorySearch)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInventoryAsync(InventoryUpdate inventoryUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
