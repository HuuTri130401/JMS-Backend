using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Application.Models.JewelryModels
{
    public class JewelryModel : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal CreatedPrice { get; set; }
        public decimal? ImportPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int Status { get; set; }
        public string? StatusName
        {
            get
            {
                return EnumName.GetJewelryStatusName().SingleOrDefault(x => x.Key == Status)?.Title;
            }
        }
        public DateTimeOffset? ImportedAt { get; set; }
        public DateTimeOffset? SoldAt { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public string BarCode { get; set; }
        public string QRCode { get; set; }
        public string SKU { get; set; }
        public string Material { get; set; }
        public decimal Weight { get; set; }
        public string Gemstone { get; set; }
        public string Size { get; set; }
        public string CertificateNumber { get; set; }
        public string ImageUrl { get; set; }
        public string Origin { get; set; }
        public string Supplier { get; set; }
    }
}
