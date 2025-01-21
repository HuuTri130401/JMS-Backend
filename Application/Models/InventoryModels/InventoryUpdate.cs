using Application.Models.InventoryDetailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.InventoryModels
{
    public class InventoryUpdate : UpdateModel
    {
        public string? Supplier { get; set; }

        public string? Note { get; set; }
    }
    public class InventoryImportUpdate : InventoryUpdate
    {
        public List<InventoryDetailsImportUpdate>? InventoryDetailsImportUpdates { get; set; }
    }

    public class InventoryExportUpdate : InventoryUpdate
    {
        public List<InventoryDetailsExportUpdate>? InventoryDetailsExportUpdates { get; set; }
    }

}
