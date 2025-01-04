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
                Data = pagedList
            };
        }

        [HttpPost]
        [Description("Thêm mới nhân viên")]
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
                        throw new Exception($"Tên người dùng '{user.UserName}' đã tồn tại trong hệ thống");
                    }

                    string code = CodeGenerator.GenerateCode("NV", 6);
                    user.Code = code;
                    user.Status = (int)Enum.UserStatus.Active;

                    bool success = await _userService.CreateAsync(user);
                    if (!success)
                    {
                        throw new AppException("Lỗi trong quá trình xử lý!");
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
                        ResultMessage = $"Thêm mới nhân viên: {user.Email} thành công!",
                        Success = success,
                    };
                }
                else
                {
                    throw new AppException("Nhân viên không tồn tại!");
                }
            }
            throw new AppException(ModelState.GetErrorMessage());
        }
    }
}
