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
        [Description("Mã nhập kho")]
        public string Code { get; set; }

        [Description("Loại giao dịch: IN (nhập), OUT (xuất)")]
        public int Type {  get; set; }

        [Description("Trạng thái phiếu xuất nhập kho (Draft, Completed, Canceled)")]
        public int Status { get; set; }

        [Description("Tham chiếu đến nguồn (nếu cần), ví dụ OrderId, Phiếu nhập...")]
        public Guid? ReferenceId { get; set; }

        [Description("Nhà cung cấp")]
        public string Supplier { get; set; }

        [Description("Giá nhập kho (Tính từ chi tiết)")]
        public decimal TotalImportPrice { get; set; }

        [Description(" Ngày nhập kho")]
        public DateTimeOffset ImportedAt { get; set; }

        [Description("Giá xuất kho (Tính từ chi tiết)")]
        public decimal TotalExportPrice { get; set; }

        [Description("Ngày xuất kho")]
        public DateTimeOffset ExportedAt { get; set; }

        [Description("Ghi chú chung")]
        public string Note { get; set; }

        // 1 Inventory - n InventoryDetails
        public List<InventoryDetails> InventoryDetails { get; set; }
    }
}
