using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Enum
    {
        /// <summary>
        /// Trạng thái tài khoản
        /// </summary>
        public enum UserStatus
        {
            NotActivated,
            Active,
            Locked,
        }
        /// <summary>
        /// Giới tính
        /// </summary>
        public enum UserGender
        {
            Unknown,
            Male,
            Female,
        }
    }
}
