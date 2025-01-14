using Application.Models.JewelryModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.InventoryDetailModels
{
    public class InventoryDetailsModel
    {
        public Guid InventoryId { get; set; } // Một Inventory có nhiều InventoryDetails
        public Guid JewelryId { get; set; } // Mỗi dòng InventoryDetails gắn với 1 Jewelry
        public decimal ImportPrice { get; set; }
        public decimal ExportPrice { get; set; }
    }
}
