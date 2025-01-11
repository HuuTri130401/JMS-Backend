using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InventoryDetails : BaseEntity
    {
        [Required]
        [Description("Mã phiếu nhập, xuất")]
        public Guid InventoryId { get; set; } // Một Inventory có nhiều InventoryDetails

        [ForeignKey("InventoryId")]
        public Inventory Inventory { get; set; }

        public Guid JewelryId { get; set; } // Mỗi dòng InventoryDetails gắn với 1 Jewelry

        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; }

        [Description("Giá nhập kho")]
        public decimal ImportPrice { get; set; }

        [Description("Giá xuất kho")]
        public decimal ExportPrice { get; set; }

    }
}
