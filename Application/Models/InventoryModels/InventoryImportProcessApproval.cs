using Application.Models.InventoryDetailModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.InventoryModels
{
    public class InventoryImportProcessApproval : UpdateModel
    {
        [Required(ErrorMessage = "Status is required!")]
        public int Status { get; set; }
        public string Note { get; set; } = string.Empty;
        public List<JewelrySellPriceProcess> JewelrySellPriceProcess { get; set; }
    }

    public class JewelrySellPriceProcess
    {
        [Required(ErrorMessage = "JewelryId is required!")]
        public Guid JewelryId { get; set; }
        [Required(ErrorMessage = "Sale price is required!")]
        public decimal SalePrice { get; set; }
    }
}
