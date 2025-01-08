using Application.Models.UserModels;
using Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using Utilities;
using AutoMapper;
using Domain.Entities;
using Enum = Utilities.Enum;
using Infrastructure.Service;

namespace API.Controllers
{
    [Description("User Management")]
    [Route("api/user")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Description("Xem danh sách người dùng")]
        public async Task<AppDomainResult> Get([FromQuery] UserSearch search)
        {

            PagedList<UserModel> pagedList = await _userService.GetPagedListUsers(search);

            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                Data = pagedList,
                ResultMessage = "Successfully retrieved the list of users."
            };
        }

        [HttpGet("{id}")]
        [Description("Xem thông tin chi tiết người dùng")]
        public async Task<AppDomainResult> GetUserById(Guid id)
        {
            UserModel userModel = await _userService.GetUserByIdAsync(id);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                Data = userModel,
                ResultMessage = "Successfully retrieved detail of user."
            };
        }

        [HttpPost]
        [Description("Thêm mới người dùng")]
        public async Task<AppDomainResult> AddUser([FromBody] UserCreate userCreate)
        {
            await _userService.CreateUserAsync(userCreate);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.Created,
                ResultMessage = "Successfully added new user",
            };
        }

        [HttpPut]
        [Description("Cập nhật người dùng")]
        public async Task<AppDomainResult> UpdateUser([FromBody] UserUpdate userUpdate)
        {
            await _userService.UpdateUserAsync(userUpdate);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Successfully updated user"
            };
        }

        [HttpDelete("{id}")]
        [Description("Xóa người dùng")]
        public async Task<AppDomainResult> DeleteById(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return new AppDomainResult
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = $"Successfully deleted user ID '{id}'."
            };
        }
    }
}
