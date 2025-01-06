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

namespace API.Controllers
{
    [Description("User Management")]
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public UserController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _emailService = serviceProvider.GetRequiredService<IEmailService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
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
                ResultMessage = "Lấy danh sách người dùng thành công."
            };
        }

        [HttpGet("{id}")]
        [Description("Xem thông tin chi tiết người dùng")]
        public async Task<AppDomainResult> GetUserById(Guid id)
        {
            Users user = await _userService.GetByIdAsync(id);
            if (user != null)
            {
                var userModel = _mapper.Map<UserModel>(user);
                return new AppDomainResult
                {
                    Success = true,
                    ResultCode = (int)HttpStatusCode.OK,
                    Data = userModel,
                    ResultMessage = "Xem thông tin chi tiết người dùng."
                };
            }
            else
            {
                throw new KeyNotFoundException($"Người dùng có id '{id}' Không tồn tại!");
            }
        }

        [HttpPost]
        [Description("Thêm mới người dùng")]
        public async Task<AppDomainResult> AddUser([FromBody] UserCreate userCreate)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<Users>(userCreate);
                if (user != null)
                {
                    IList<Users> existingUser = await _userService.GetListAsync(x => x.Deleted == false
                    && (x.Email == user.Email || x.Phone == user.Phone || x.UserName == user.UserName),
                    x => new Users { Id = x.Id, Email = x.Email, Phone = x.Phone, UserName = x.UserName });

                    if (existingUser.Any(x => x.Email == user.Email) && !string.IsNullOrEmpty(user.Email))
                    {
                        throw new AppException($"Email '{user.Email}' đã tồn tại trong hệ thống!");
                    }

                    if (existingUser.Any(x => x.Phone == user.Phone) && !string.IsNullOrEmpty(user.Phone))
                    {
                        throw new Exception($"Số điện thoại '{user.Phone}' đã tồn tại trong hệ thống!");
                    }

                    if (existingUser.Any(x => x.UserName == user.UserName) && !string.IsNullOrEmpty(user.UserName))
                    {
                        throw new Exception($"Tên người dùng '{user.UserName}' đã tồn tại trong hệ thống!");
                    }

                    string code = CodeGenerator.GenerateCode("ND", 6);
                    user.Code = code;
                    user.Status = (int)Enum.UserStatus.Active;
                    user.Password = SecurityUtilities.HashSHA1(user.Password);
                    //user.CreatedBy = LoginContext.Instance?.CurrentUser.UserId;

                    bool success = await _userService.CreateAsync(user);
                    if (!success)
                    {
                        throw new AppException("Lỗi trong quá trình thêm mới người dùng!");
                    }
                    string link = "Https://";
                    string content = $"<p>Thông tin tài khoản đăng nhập hệ thống HTJ</p>";
                    content = content + $"<p><b>Tài khoản: {user.UserName}</b></p>";
                    content = content + $"<p><b>Mật khẩu: {userCreate.Password}</b></p>";
                    content = content + $"<p>Vui lòng không cung cấp thông tin này cho người khác.</p>";
                    content = content + $"<p>Truy cập <a href=\"{link}\">tại đây</a> để sử dụng phần mềm.</p>";

                    await _emailService.SendEmailAsync(user.Email, "HTJ - THÔNG TIN TÀI KHOẢN SỬ DỤNG PHẦN MỀM", content);

                    return new AppDomainResult()
                    {
                        ResultCode = (int)HttpStatusCode.Created,
                        ResultMessage = $"Thêm mới người dùng: {user.Email} thành công.",
                        Success = success,
                    };
                }
                else
                {
                    throw new AppException("Người dùng không tồn tại!");
                }
            }
            else
            {
                throw new AppException(ModelState.GetErrorMessage());
            }
        }

        [HttpPut]
        [Description("Cập nhật người dùng")]
        public async Task<AppDomainResult> UpdateUser([FromBody] UserUpdate userUpdate)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetByIdAsync(userUpdate.Id);
                if (user == null)
                {
                    throw new KeyNotFoundException($"Người dùng '{userUpdate.Id}' không tồn tại!");
                }
                var item = _mapper.Map<Users>(userUpdate);
                if (item != null)
                {
                    IList<Users> existingUser = await _userService.GetListAsync(x => x.Deleted == false
                        && (x.Email == user.Email || x.Phone == user.Phone || x.UserName == user.UserName),
                        x => new Users { Id = x.Id, Phone = x.Phone, UserName = x.UserName });

                    if (existingUser.Any(x => x.Phone == userUpdate.Phone) && !string.IsNullOrEmpty(userUpdate.Phone))
                    {
                        throw new Exception($"Số điện thoại '{userUpdate.Phone}' đã tồn tại trong hệ thống!");
                    }

                    if (existingUser.Any(x => x.UserName == userUpdate.UserName) && !string.IsNullOrEmpty(userUpdate.UserName))
                    {
                        throw new Exception($"Tên người dùng '{userUpdate.UserName}' đã tồn tại trong hệ thống!");
                    }

                    //if (LoginContext.Instance?.CurrentUser == null)
                    //{
                    //    throw new AppException("User is not authenticated.");
                    //}

                    //item.UpdatedBy = LoginContext.Instance?.CurrentUser.UserId;

                    bool success = await _userService.UpdateAsync(item);
                    if (!success)
                    {
                        throw new AppException("Lỗi trong quá trình cập nhật người dùng!");
                    }
                    return new AppDomainResult
                    {
                        Success = success,
                        ResultCode = (int)HttpStatusCode.OK,
                        ResultMessage = $"Cập nhật người dùng '{userUpdate.Id}' thành công.",
                    };
                }
                else
                {
                    throw new KeyNotFoundException($"Người dùng có id '{userUpdate.Id}' không tồn tại!");
                }
            }
            else
            {
                throw new AppException(ModelState.GetErrorMessage());
            }
        }

        [HttpDelete("{id}")]
        [Description("Xóa người dùng")]
        public async Task<AppDomainResult> DeleteById(Guid id)
        {
            Users user = await _userService.DeleteDataAsync(id);
            if (user != null)
            {
                return new AppDomainResult
                {
                    Success = true,
                    ResultCode = (int)HttpStatusCode.OK,
                    ResultMessage = $"Xóa người dùng id '{id}' thành công."
                };
            }
            else
            {
                throw new KeyNotFoundException($"Người dùng id '{id}' không tồn tại!");
            }
        }
    }
}
