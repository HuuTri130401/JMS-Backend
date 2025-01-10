using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventory : BaseEntity
    {
        [Required]
        [Description("Mã sản phẩm xuất nhập kho")]
        public Guid JewelryId { get; set; }

        [ForeignKey("JewelryId")] 
        [Description("Khóa ngoại tới sản phẩm")]
        public Jewelry Jewelry { get; set; }

        [Description("Loại giao dịch: IN (nhập), OUT (xuất)")]
        public int Type {  get; set; }

        [Description("Trạng thái xuất nhập kho")]
        public int Status { get; set; }

        [Description("Tham chiếu đến nguồn (nếu cần), ví dụ OrderId, Phiếu nhập...")]
        public Guid? ReferenceId { get; set; }

        [Description("Giá nhập kho")]
        public decimal ImportPrice { get; set; }

        [Description(" Ngày nhập kho")]
        public DateTimeOffset ImportedAt { get; set; }

        [Description("Nhà cung cấp")]
        public string Supplier { get; set; }

        [Description("Giá xuất kho")]
        public decimal ExportPrice { get; set; }

        [Description("Ngày xuất kho")]
        public DateTimeOffset ExportedAt { get; set; }
    }
}
