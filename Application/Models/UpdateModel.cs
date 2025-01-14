using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UpdateModel 
    {
        [Required(ErrorMessage = "Id is required for updating")]
        public Guid Id { get; set; }
        public DateTimeOffset updated
        {
            get
            {
                return DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
            }
        }
    }
}
