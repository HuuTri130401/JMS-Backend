using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? Deleted { get; set; } = false;
        public bool? IsActive { get; set; } = true;
        public string? CreatedByName { get; set; }
        public string? CreatedByCode { get; set; }
    }
}
