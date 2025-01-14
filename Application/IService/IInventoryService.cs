using Application.Models;
using Application.Models.InventoryModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Application.IService
{
    public interface IInventoryService : IGenericDomainService<Inventory, InventorySearch>
    {
        Task<PagedList<InventoryModel>> GetPagedListInventories(InventorySearch inventorySearch);
        Task<InventoryModel> GetInventoryByIdAsync(Guid id);
        Task CreateImportInventoryAsync(InventoryImportCreate inventoryImportCreate);
        Task CreateExportInventoryAsync(InventoryExportCreate inventoryExportCreate);
        Task UpdateInventoryAsync(InventoryUpdate inventoryUpdate);
        Task ProcessImportInventory(InventoryImportProcessApproval statusModel);
        Task DeleteInventoryAsync(Guid id);
    }
}
