using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.UserModels
{
    public class UserCreate : CreateModel
    {
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        [StringLength(100, ErrorMessage = "Số kí tự của email phải nhỏ hơn 100!")]
        public string Email { get; set; }
        public string? Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string IdentityCard { get; set; }
        [StringLength(255, ErrorMessage = "Mật khẩu phải lớn hơn 8 kí tự", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? Gender { get; set; }

    }
}
