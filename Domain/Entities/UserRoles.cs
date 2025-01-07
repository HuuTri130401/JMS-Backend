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
        public Guid UsersId { get; set; }
        public Users Users { get; set; }
        public Guid RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}
