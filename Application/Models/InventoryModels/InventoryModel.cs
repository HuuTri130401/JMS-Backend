using Application.Models.InventoryDetailModels;
using Application.Models.JewelryModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Application.Models.InventoryModels
{
    public class InventoryModel : BaseModel
    {
        public string Code { get; set; }
        public int Type { get; set; }
        public string? TypeName 
        {
            get
            {
                return EnumName.GetInventortyTypeName().SingleOrDefault(x => x.Key == Type)?.Title;
            } 
        } 
        public int Status { get; set; }
        public string? StatusName
        {
            get
            {
                return EnumName.GetInventortyStatusName().SingleOrDefault(x => x.Key == Status)?.Title;
            }
        }
        public Guid? ReferenceId { get; set; }
        public string Supplier { get; set; }
        public decimal TotalImportPrice { get; set; }
        public DateTimeOffset ImportedAt { get; set; }
        public decimal TotalExportPrice { get; set; }
        public DateTimeOffset ExportedAt { get; set; }
        public string Note { get; set; }
        public List<InventoryDetailsModel> InventoryDetails { get; set; }
        public List<JewelryModel> JewelryModels { get; set;}
    }
}
