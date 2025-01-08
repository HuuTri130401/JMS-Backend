using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.BaseEntities;
using System.ComponentModel;

namespace Domain.Entities
{
    public class ImportRecord : BaseEntity
    {
        [Required]
        [Description("Mã sản phẩm nhập kho")]
        public Guid JewelryId { get; set; }

        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; }

        [Required]
        [Description("Giá nhập kho")]
        public decimal ImportPrice { get; set; } 

        [Required]
        [Description(" Ngày nhập kho")]
        public DateTimeOffset ImportedAt { get; set; }

        [Description("Nhà cung cấp")]
        public string Supplier { get; set; }
        [Description("Trạng thái nhập kho")]
        public int Status { get; set; }
    }
}
