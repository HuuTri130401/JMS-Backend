using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UpdateStatusModel
    {
        [Required(ErrorMessage = "Id is required!")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Status is required!")]
        public int Status { get; set; }
        public string? Note { get; set; } 
    }
}
