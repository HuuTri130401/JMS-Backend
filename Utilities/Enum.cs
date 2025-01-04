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
    }
}
