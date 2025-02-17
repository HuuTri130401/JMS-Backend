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
        public async Task<AppDomainResult> GetOrders([FromQuery]OrderSearch orderSearch)
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

    }
}
