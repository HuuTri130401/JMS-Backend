using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.InventoryDetailModels
{
    public class InventoryDetailsCreate : CreateModel
    {
        //[Required(ErrorMessage = "InventoryId is required!")]
        //public Guid InventoryId { get; set; }

        [Required(ErrorMessage = "JewelryId is required!")]
        public Guid JewelryId { get; set; }
    }

    public class InventoryDetailsImportCreate : InventoryDetailsCreate
    {
        [Required(ErrorMessage = "ImportPrice is required!")]
        public decimal ImportPrice { get; set; }
    }

    public class InventoryDetailsExportCreate : InventoryDetailsCreate
    {
        [Required(ErrorMessage = "ExportPrice is required!")]
        public decimal ExportPrice { get; set; }
    }
}
