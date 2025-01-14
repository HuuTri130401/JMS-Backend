using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.UserModels
{
    public class UserModel : BaseModel
    {
        public string Code { get; set; }
        public string UserName { get; set; }
        public string? FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public int? Status { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public string IdentityCard { get; set; }
        public int? Gender { get; set; }
        public bool IsAdmin { get; set; } = false;
        public decimal PurchaseRevenue { get; set; } = 0; 
    }
}
