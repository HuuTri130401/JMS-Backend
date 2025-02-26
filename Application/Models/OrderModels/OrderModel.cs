using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Domain.Entities;
using Application.Models.JewelryModels;

namespace Application.Models.OrderModels
{
    public class OrderModel : BaseModel
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public string? StatusName
        {
            get { return EnumName.GetOrderStatusName().SingleOrDefault(x => x.Key == Status)?.Title; }
        }
        public decimal TotalAmount { get; set; }
        public string Note { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<JewelryModel> JewelryModels { get; set; }
    }
}
