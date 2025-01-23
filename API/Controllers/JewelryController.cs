using Application.IService;
using Application.Models;
using Application.Models.JewelryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using Utilities;

namespace API.Controllers
{
    [Description("Jewelry Management")]
    [Route("api/jewelry")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class JewelryController : ControllerBase
    {
        private readonly IJewelryService _jewelryService;

        public JewelryController(IJewelryService jewelryService)
        {
            _jewelryService = jewelryService;
        }

        [HttpGet]
        [Description("Xem danh sách trang sức")]
        public async Task<AppDomainResult> Get([FromQuery] JewelrySearch jewelrySearch)
        {
            PagedList<JewelryModel> pagedList = await _jewelryService.GetPagedListJewelry(jewelrySearch);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                Data = pagedList,
                ResultMessage = "Successfully retrieved the list of jewelry."
            };
        }

        [HttpGet("{id}")]
        [Description("Xem thông tin chi tiết jewelry")]
        public async Task<AppDomainResult> GetJewelryById(Guid id)
        {
            JewelryModel jewelryModel = await _jewelryService.GetJewelryByIdAsync(id);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                Data = jewelryModel,
                ResultMessage = "Successfully retrieved detail of jewelry"
            };
        }

        [HttpPost]
        [Description("Thêm mới trang sức")]
        public async Task<AppDomainResult> AddJewelry([FromBody] JewelryCreate jewelryCreate)
        {
            await _jewelryService.CreateJewelrAsync(jewelryCreate);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.Created,
                ResultMessage = "Successfully added new jewelry",
            };
        }

        [HttpPut]
        [Description("Cập nhật trang sức")]
        public async Task<AppDomainResult> UpdateJewelry([FromBody] JewelryUpdate jewelryUpdate)
        {
            await _jewelryService.UpdateJewelrAsync(jewelryUpdate);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Successfully updated jewelry",
            };
        }

        [HttpPut("approval")]
        [Description("Duyệt trang sức")]
        public async Task<AppDomainResult> ApprovalJewelry([FromBody] UpdateStatusModel updateStatus)
        {
            JewelryModel jewelryModel = await _jewelryService.UpdateStatusJewelry(updateStatus);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                Data = jewelryModel,
                ResultMessage = "Successfully updated jewelry status!"
            };
        }

        [HttpDelete("{id}")]
        [Description("Xóa trang sức")]
        public async Task<AppDomainResult> DeleteJewelry(Guid id)
        {
            await _jewelryService.DeleteJewelryAsync(id);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Successfully deleted jewelry",
            };
        }
    }
}
