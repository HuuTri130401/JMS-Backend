using Application.IService;
using Application.Models.InventoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using Utilities;

namespace API.Controllers
{
    [Description("Inventory Management")]
    [Route("api/inventory")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class InventoriesController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoriesController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost]
        [Description("Tạo mới phiên nhập kho")]
        public async Task<AppDomainResult> ImportInventory(InventoryImportCreate create)
        {
            await _inventoryService.CreateImportInventoryAsync(create);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.Created,
                ResultMessage = "Successfully created new inventory."
            };
        }
    }

}
