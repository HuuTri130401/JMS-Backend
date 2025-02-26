using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.OrderModels
{
    public class OrderUpdate : UpdateModel
    {
        [Required(ErrorMessage = "OrderId is required!")]
        public Guid Id { get; set; } 

        public Guid? CustomerId { get; set; } 
        public string Note { get; set; } 

        public List<Guid> JewelryIds { get; set; } 

        public int? Status { get; set; } 
    }

}
