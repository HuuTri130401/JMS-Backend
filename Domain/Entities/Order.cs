using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        [Description("Mã khách hàng")]
        public Guid CustomerId { get; set; }

        [Description("Mã đơn hàng")]
        public string Code { get; set; }

        [Required]
        [Description("Trạng thái đơn hàng")]
        public int Status { get; set; }

        [Description("Tổng giá trị đơn hàng")]
        public decimal TotalAmount { get; set; }
        [Description("Ghi chú")]
        public string Note { get; set; }

        // 1 Order có thể có nhiều OrderDetails
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        [NotMapped]     
        public string CustomerName { get; set; }
    }
}
