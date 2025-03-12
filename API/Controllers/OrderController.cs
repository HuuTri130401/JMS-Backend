using Application.IService;
using Application.Models.OrderModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using Utilities;

namespace API.Controllers
{
    [Description("Order Management")]
    [Route("api/order")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Description("Xem danh sách đơn hàng")]
        public async Task<AppDomainResult> GetOrders([FromQuery] OrderSearch orderSearch)
        {
            PagedList<OrderModel> pagedList = await _orderService.GetPagedListOrderAsync(orderSearch);
            return new AppDomainResult
            {
                Data = pagedList,
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Successfully retrieved the list of orders"
            };
        }

        [HttpGet("{id}")]
        [Description("Xem thông tin chi tiết đơn hàng.")]
        public async Task<AppDomainResult> GetOrderById(Guid id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            return new AppDomainResult
            {
                Data = result,
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Successfully retrieved detail of order"
            };
        }

        [HttpPost]
        [Description("Tạo mới đơn hàng")]
        public async Task<AppDomainResult> CreateOrder(OrderCreate orderCreate)
        {
            await _orderService.CreateOrderAsync(orderCreate);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.Created,
                Data = null,
                ResultMessage = "Successfully added new order"
            };
        }

        [HttpPut]
        [Description("Cập nhật đơn hàng")]
        public async Task<AppDomainResult> UpdateOrder([FromBody] OrderUpdate orderUpdate)
        {
            await _orderService.UpdateOrderAsync(orderUpdate);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                Data = null,
                ResultMessage = "Successfully updated the order"
            };
        }

        [HttpDelete("{id}")]
        [Description("Xóa đơn hàng")]
        public async Task<AppDomainResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteOrderAsync(id);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Successfully deleted the order"
            };
        }
    }
}
