using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRoles : BaseEntity
    {
        public Guid UserId { get; set; }
        public User Users { get; set; }
        public Guid RoleId { get; set; }
        public Role Roles { get; set; }
    }
}
