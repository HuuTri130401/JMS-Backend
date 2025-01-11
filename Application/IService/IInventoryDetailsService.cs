using Application.Models.InventoryDetailModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IInventoryDetailsService : IGenericDomainService<InventoryDetails, InventoryDetailsSearch>
    {
        Task CreateInventoryImportDetailAsync(InventoryDetailsImportCreate create);
        Task CreateInventoryExportDetailAsync(InventoryDetailsExportCreate create);
    }
}
