using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.OrderModels
{
    public class OrderCreate : CreateModel
    {
        [Required(ErrorMessage = "CustomerId is required!")]
        public Guid CustomerId { get; set; }
        public string Note { get; set; }

        [Required(ErrorMessage = "Jewelry is required in order")]
        public List<Guid> JewelryIds { get; set; }
    }
}
