using Application.Models.OrderModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Application.IService
{
    public interface IOrderService : IGenericDomainService<Order, OrderSearch>
    {
        Task<PagedList<OrderModel>> GetPagedListOrderAsync(OrderSearch orderSearch);
        Task<OrderModel> GetOrderByIdAsync(Guid id);
        Task CreateOrderAsync(OrderCreate order);
        Task UpdateOrderAsync(OrderUpdate order);
        Task DeleteOrderAsync(Guid id);
    }
}
