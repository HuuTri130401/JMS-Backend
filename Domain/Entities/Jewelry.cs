﻿using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Jewelry : BaseEntity
    {
        [Required]
        [StringLength(100)]
        [Description("Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Description("Mã sản phẩm")]
        public string Code { get; set; } = string.Empty;

        [Description("Mô tả chi tiết")]
        public string? Description { get; set; } 

        [Required]
        [Description("Giá ước tính khi tạo")]
        public decimal CreatedPrice { get; set; }

        [Description("Giá khi nhập kho")]
        public decimal? ImportPrice { get; set; }

        [Description("Giá khi bán ra")]
        public decimal? SalePrice { get; set; }

        /// <summary>
        /// Trạng thái
        /// 0 - Chờ duyệt
        /// 1 - Chờ nhập kho
        /// 2 - Có thể bán
        /// 3 - Đã bán
        /// 4 - Hủy
        /// </summary>
        [Required]
        [Description("Trạng thái sản phẩm")] 
        public int Status { get; set; } 

        [Description("Ngày nhập kho")]
        public DateTimeOffset? ImportedAt { get; set; }

        [Description("Ngày bán")]
        public DateTimeOffset? SoldAt { get; set; }

        [Description("Ghi chú")]
        public string? Note { get; set; }

        [Description("Màu trang sức")]
        public string? Color { get; set; }

        [Description("BarCode")]
        public string? BarCode { get; set; }

        [Description("QRCode")]
        public string? QRCode { get; set; }

        [Required]
        [StringLength(50)]
        [Description("Mã SKU (Stock Keeping Unit)")]
        public string SKU { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Description("Chất liệu (Vàng, Bạc, Bạch Kim, v.v.)")]
        public string Material { get; set; } = string.Empty;

        [Description("Trọng lượng (gram)")]
        public decimal Weight { get; set; }

        [StringLength(50)]
        [Description("Loại đá quý (Kim cương, Ruby, Sapphire, v.v.)")]
        public string Gemstone { get; set; } = string.Empty;

        [StringLength(50)]
        [Description("Kích thước (Ví dụ: 15cm, 20mm, Size 6, v.v.)")]
        public string? Size { get; set; } 

        [StringLength(200)]
        [Description("Số chứng nhận chất lượng")]
        public string? CertificateNumber { get; set; } 

        [StringLength(200)]
        [Description("URL hình ảnh sản phẩm")]
        public string? ImageUrl { get; set; } 

        [Description("Xuất xứ sản phẩm (quốc gia sản xuất)")]
        public string? Origin { get; set; }
        
        [Description("Nhà cung cấp")] 
        public string? Supplier { get; set; }

        // Liên kết với OrderDetail nếu đã được bán
<<<<<<< Updated upstream
        public OrderDetail? OrderDetail { get; set; }
=======
        // Mỗi Jewelry có thể xuất hiện trong nhiều OrderDetails (dù thực tế bán 1 lần, 
        // nhưng về logic DB, 1-n vẫn hợp lệ).
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        // -- 1 Jewelry có thể có n InventoryDetails (1 nhập 1 xuất ...)  --
        public List<InventoryDetails> InventoryDetails { get; set; } = new List<InventoryDetails>();
>>>>>>> Stashed changes
    }
}
