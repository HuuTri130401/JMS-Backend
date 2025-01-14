using Application.IService;
using Application.Models;
using Application.Models.InventoryModels;
using Domain.BaseEntities;
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

        [HttpGet]
        [Description("Danh sách phiên xuất/ nhập kho")]
        public async Task<AppDomainResult> GetInventories([FromQuery] InventorySearch inventorySearch)
        {
            PagedList<InventoryModel> pagedList = await _inventoryService.GetPagedListInventories(inventorySearch);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Successfully retrieved the list of inventories",
                Data = pagedList
            };
        }

        [HttpGet("{id}")]
        [Description("Thông tin chi tiết xuất/ nhập kho")]
        public async Task<AppDomainResult> GetInventoryById(Guid id)
        {
            var result = await _inventoryService.GetInventoryByIdAsync(id);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = $"Successfully retrieved the inventory detail Id '{id}'",
                Data = result
            };
        }

        [HttpPost("import")]
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

        [HttpPut("update-status")]
        [Description("Cập nhật xuất/ nhập kho")]
        public async Task<AppDomainResult> UpdateStatus(InventoryImportProcessApproval statusModel)
        {
            await _inventoryService.ProcessImportInventory(statusModel);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Successfully updated status inventory"
            };
        }
    }
}
