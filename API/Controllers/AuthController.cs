using Application.Models.UserModels;
using Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using Utilities;

namespace API.Controllers
{
    [Description("Auth Management")]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IServiceProvider serviceProvider)
        {
            _authService = serviceProvider.GetRequiredService<IAuthService>();
        }

        [HttpPost("login")]
        public async Task<AppDomainResult> Login(LoginModel loginModel)
        {
            var result = await _authService.Login(loginModel);

            return new AppDomainResult
            {
                Success = true,
                ResultMessage = "Login thành công",
                Data = result,
                ResultCode = (int)HttpStatusCode.OK
            };
        }
    }
}
