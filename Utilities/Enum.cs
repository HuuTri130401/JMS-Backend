using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Enum;

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
            PendingApproval,   // Yêu Cầu Duyệt
            AwaitingStockIn,   // Chờ Nhập Kho
            AvailableForSale,  // Có Thể Bán
            Sold,              // Đã Bán
            Cancelled,         // Hủy
            AwaitingStockOut,  // Chờ Xuất Kho
            Discarded          // Xuất Bỏ
        }
    }

    public partial class EnumName
    {
        public static List<EnumObject> GetJewelryStatusName()
        {
            return new List<EnumObject>()
            {
                new EnumObject { Key = (int)JewelryStatus.PendingApproval, Title = "Pending Approval"},
                new EnumObject { Key = (int)JewelryStatus.AwaitingStockIn, Title = "Awaiting Stock In"},
                new EnumObject { Key = (int)JewelryStatus.AvailableForSale, Title = "Available For Sale"},
                new EnumObject { Key = (int)JewelryStatus.Sold, Title = "Sold"},
                new EnumObject { Key = (int)JewelryStatus.Cancelled, Title = "Cancelled"},
                new EnumObject { Key = (int)JewelryStatus.AwaitingStockOut, Title = "Awaiting Stock Out"},
                new EnumObject { Key = (int)JewelryStatus.Discarded, Title = "Discarded"},
            };
        }
    }

    public class EnumObject
    {
        public int Key { get; set; }
        public string Title { get; set; }
    }
}
