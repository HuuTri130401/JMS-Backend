using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public partial class Enum
    {
        /// <summary>
        /// Trạng thái tài khoản
        /// </summary>
        public enum UserStatus
        {
            Active = 1,
            Locked = 2,
            NotActivated = 3,
        }

        /// <summary>
        /// Giới tính
        /// </summary>
        public enum UserGender
        {
            /// <summary>
            /// nữ
            /// </summary>
            Female = 1,
            /// <summary>
            /// nam
            /// </summary>
            Male = 2,
            /// <summary>
            /// khác
            /// </summary>
            Other = 3
        }

        public enum JewelryStatus
        {
<<<<<<< Updated upstream
            PendingApproval,   // Yêu Cầu Duyệt
            AwaitingStockIn,   // Chờ Nhập Kho
            AvailableForSale,  // Có Thể Bán
            Sold,              // Đã Bán
            Cancelled,         // Hủy
            AwaitingStockOut,  // Chờ Xuất Kho
            Discarded          // Xuất Bỏ
=======
            /// <summary>
            /// Yêu Cầu Duyệt
            /// </summary>
            PendingApproval = 1,

            /// <summary>
            /// Chờ Nhập Kho
            /// </summary>
            AwaitingStockIn = 2,

            /// <summary>
            ///Có Thể Bán
            /// </summary>
            AvailableForSale = 3,  

            /// <summary>
            /// Đã Bán
            /// </summary>
            Sold = 4,              

            /// <summary>
            /// Hủy
            /// </summary>
            Cancelled = 5,         

            /// <summary>
            /// Chờ Xuất Kho
            /// </summary>
            AwaitingStockOut = 6,  

            /// <summary>
            /// Xuất Bỏ
            /// </summary>
            Discarded = 7          
        }

        /// <summary>
        /// Xuất/Nhập kho
        /// </summary>
        public enum InventoryEnum
        {
            /// <summary>
            /// Lưu tạm
            /// </summary>
            Temporary = 1,
            /// <summary>
            /// Đã duyệt
            /// </summary>
            Approved = 2,
            /// <summary>
            /// Không duyệt
            /// </summary>
            NotApproved = 3
        }

        /// <summary>
        /// Loại Xuất/Nhập kho
        /// </summary>
        public enum InventoryTypeEnum
        {
            /// <summary>
            /// Nhập kho
            /// </summary>
            Import = 1,
            /// <summary>
            /// Xuất kho
            /// </summary>
            Export = 2,
>>>>>>> Stashed changes
        }
    }
}
