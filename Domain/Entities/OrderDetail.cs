using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        [Required]
        [Description("Mã đơn hàng")]
        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        [Description("Mã sản phẩm")]
        public Guid JewelryId { get; set; }

        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; }

        [Required]
        [Description("Giá bán (tại thời điểm mua)")] 
        public decimal SalePrice { get; set; }

        [Description("Ngày bán")]
        public DateTimeOffset SoldAt { get; set; } 
    }
}
