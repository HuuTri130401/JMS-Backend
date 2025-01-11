using Application.Models.UserModels;
using Application.IRepository;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Enum;
using Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace Infrastructure.Service
{
    public class AuthService : BaseDomainService<User, UserSearch>, IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper, IConfiguration configuration, IAppUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            // Thêm role vào Claim
            // Kiểm tra UserRoles không null
            if (user.UserRoles != null)
            {
                var roles = user.UserRoles
                    .Where(ur => ur.Roles != null) // Đảm bảo Role không null
                    .Select(ur => ur.Roles.RoleName)
                    .Distinct()
                    .ToList();

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<string> GenerateRefreshToken()
        {
            try
            {
                return await Task.Run(() =>
                {
                    var randomNumber = new byte[32];
                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(randomNumber);
                        return Convert.ToBase64String(randomNumber);
                    }
                });
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<UserLoginResponseModel> Login(LoginModel request)
        {
            User user = await Queryable
                .Include(u => u.UserRoles) // Nạp UserRoles
                    .ThenInclude(ur => ur.Roles) // Nạp Role từ UserRoles
                .Where(e => e.Deleted == false && (e.UserName == request.UserName))
                .FirstOrDefaultAsync();

            if (user != null)
            {
                if (user.Status == (int)UserStatus.Locked)
                    throw new AppException("Tài khoản bạn đã bị khóa. Vui lòng liên hệ quản trị!");

                var userModel = _mapper.Map<UserModel>(user);
                var token = await GenerateJwtToken(user);
                var refreshToken = await GenerateRefreshToken();

                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(180);
                user.RefreshToken = refreshToken;
                var refreshTokenExpiryTime = user.RefreshTokenExpiryTime;
                _unitOfWork.Repository<User>().UpdateFieldsSave(user, x => x.RefreshToken, x => x.RefreshTokenExpiryTime);
                await _unitOfWork.SaveAsync();

                return new UserLoginResponseModel()
                {
                    Token = "Bearer " + token,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiryTime = refreshTokenExpiryTime,
                };
            }
            return null;
        }
    }
}
