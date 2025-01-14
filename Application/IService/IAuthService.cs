using Application.Models.UserModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IAuthService : IGenericDomainService<User, UserSearch>
    {
        Task<string> GenerateRefreshToken();
        Task<string> GenerateJwtToken(User user);
        Task<UserLoginResponseModel> Login(LoginModel request);
    }
}
