﻿using System;
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
        /// Trạng thái đơn hàng
        /// </summary>
        public enum OrderStatus
        {
            /// <summary>
            /// Đang xử lí
            /// </summary>
            Processing = 1,
            /// <summary>
            /// Xác nhận
            /// </summary>
            Approved = 2,
            /// <summary>
            /// Hoàn thành
            /// </summary>
            Success = 3,
            /// <summary>
            /// Hủy
            /// </summary>
            Cancel = 4,
        }

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
            /// Nữ
            /// </summary>
            Female = 1,
            /// <summary>
            /// Nam
            /// </summary>
            Male = 2,
            /// <summary>
            /// Khác
            /// </summary>
            Other = 3
        }

        public enum JewelryStatus
        {
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
            Discarded = 7,
            /// <summary>
            /// Đã duyệt  -- Bổ sung sau
            /// </summary>
            Approved = 8
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
        }
    }

    public partial class EnumName
    {
        public static List<EnumObject> GetOrderStatusName()
        {
            return new List<EnumObject>()
            {
                new EnumObject {Key = (int)OrderStatus.Processing, Title = "Processing"},
                new EnumObject {Key = (int)OrderStatus.Approved, Title = "Approved"},
                new EnumObject {Key = (int)OrderStatus.Success, Title = "Success"},
                new EnumObject {Key = (int)OrderStatus.Cancel, Title = "Cancel"},
            };
        }

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
                new EnumObject { Key = (int)JewelryStatus.Approved, Title = "Approved"},
            };
        }

        public static List<EnumObject> GetInventortyStatusName()
        {
            return new List<EnumObject>()
            {
                new EnumObject { Key = (int)InventoryEnum.Temporary, Title = "Temporary"},
                new EnumObject { Key = (int)InventoryEnum.Approved, Title = "Approved"},
                new EnumObject { Key = (int)InventoryEnum.NotApproved, Title = "Not Approved"},
            };
        }

        public static List<EnumObject> GetInventortyTypeName()
        {
            return new List<EnumObject>()
            {
                new EnumObject { Key = (int)InventoryTypeEnum.Import, Title = "Import"},
                new EnumObject { Key = (int)InventoryTypeEnum.Export, Title = "Export"},
            };
        }
        public static List<EnumObject> GetGenderName()
        {
            return new List<EnumObject>()
            {
                new EnumObject { Key = (int)UserGender.Female, Title = "Female"},
                new EnumObject { Key = (int)UserGender.Male, Title = "Male"},
                new EnumObject { Key = (int)UserGender.Other, Title = "Other"},
            };
        }
    }

    public class EnumObject
    {
        public int Key { get; set; }
        public string Title { get; set; }
    }
}
