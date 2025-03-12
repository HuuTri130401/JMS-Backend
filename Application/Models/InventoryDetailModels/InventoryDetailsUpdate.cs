using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.InventoryDetailModels
{
    public class InventoryDetailsUpdate
    {
        [Required(ErrorMessage = "JewelryId is required!")]
        public Guid JewelryId { get; set; }
        public DateTimeOffset updated
        {
            get
            {
                return DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
            }
        }
    }
    public class InventoryDetailsImportUpdate : InventoryDetailsUpdate
    {
        [Required(ErrorMessage = "ImportPrice is required!")]
        public decimal ImportPrice { get; set; }
    }

    public class InventoryDetailsExportUpdate : InventoryDetailsUpdate
    {
        [Required(ErrorMessage = "ExportPrice is required!")]
        public decimal ExportPrice { get; set; }
    }
}
