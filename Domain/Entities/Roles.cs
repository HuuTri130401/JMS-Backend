using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Roles : BaseEntity
    {
        public string RoleName { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
