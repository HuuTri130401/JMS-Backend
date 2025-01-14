using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.InventoryDetailModels;

namespace Application.Models.InventoryModels
{
    public class InventoryCreate : CreateModel
    {
        public string Supplier { get; set; }

        public string Note { get; set; }
    }

    public class InventoryImportCreate : InventoryCreate
    {
        public List<InventoryDetailsImportCreate> InventoryDetailsImportCreates { get; set; }
    }

    public class InventoryExportCreate : InventoryCreate
    {
        public List<InventoryDetailsExportCreate> InventoryDetailsExportCreates { get; set; }
    }
}
