using Application.Models.UserModels;
using Application.IRepository;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Net;

namespace Infrastructure.Service
{
    public class UserService : BaseDomainService<Users, UserSearch>, IUserService
    {
        /// <summary>
        /// private: dùng nội bộ class UserService
        /// readonly: chỉ khởi tạo duy nhất 1 lần , không thể thay đổi sau khi khởi tạo
        ///     ở đây là khởi tạo trong constructor
        /// protected readonly tương tự, tuy nhiên có thể dùng cho class con kế thừa
        /// </summary>
        private readonly IConfiguration _configuaration;
        private readonly IEmailService _emailService;
        /*
         base(unitOfWork, mapper) gọi đến constructor của lớp cha (BaseDomainService), và mục đích của base là để truyền các dependency 
         từ UserService lên BaseDomainService. Điều này có nghĩa là UserService không cần khởi tạo lại IAppUnitOfWork và IMapper, mà chỉ 
         cần truyền chúng lên lớp cha để BaseDomainService xử lý.
         */
        public UserService(IEmailService emailService, IConfiguration configuaration, IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _configuaration = configuaration;
            _emailService = emailService;
        }

        public async Task<PagedList<UserModel>> GetPagedListUsers(UserSearch baseSearch)
        {
            PagedList<Users> listUsers = await GetPagedListData(baseSearch);
            PagedList<UserModel> listUsersModel = _mapper.Map<PagedList<UserModel>>(listUsers);
            return listUsersModel;
        }

        protected override string GetStoreProcName()
        {
            return "GetPagedData_User";
        }

        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            Users user = await GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID '{id}' does not exist.");
            }
            UserModel userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }

        public async Task CreateUserAsync(UserCreate userCreate)
        {
            if (userCreate == null)
            {
                throw new AppException("UserCreate cannot be null!");
            }

            var user = _mapper.Map<Users>(userCreate);
            IList<Users> existingUser = await GetListAsync(x => x.Deleted == false
            && (x.Email == user.Email || x.Phone == user.Phone || x.UserName == user.UserName),
            x => new Users { Id = x.Id, Email = x.Email, Phone = x.Phone, UserName = x.UserName });

            if (existingUser.Any(x => x.Email == user.Email) && !string.IsNullOrEmpty(user.Email))
            {
                throw new AppException($"Email '{user.Email}' already exist in system!!");
            }

            if (existingUser.Any(x => x.Phone == user.Phone) && !string.IsNullOrEmpty(user.Phone))
            {
                throw new Exception($"Phone number '{user.Phone}' already exist in system!!");
            }

            if (existingUser.Any(x => x.UserName == user.UserName) && !string.IsNullOrEmpty(user.UserName))
            {
                throw new Exception($"Username '{user.UserName}' already exist in system!");
            }

            string code = CodeGenerator.GenerateCode("USER", 4);
            user.Code = code;
            user.Status = (int)Utilities.Enum.UserStatus.Active;
            user.Password = SecurityUtilities.HashSHA1(user.Password);

            Console.WriteLine($"LoginContext.Instance: {(LoginContext.Instance != null ? "Exists" : "Null")}");
            Console.WriteLine($"CurrentUser: {(LoginContext.Instance?.CurrentUser != null ? "Exists" : "Null")}");
            Console.WriteLine($"UserId: {LoginContext.Instance?.CurrentUser?.UserId.ToString() ?? "Null"}");

            //user.CreatedBy = LoginContext.Instance?.CurrentUser.UserId;

            bool success = await CreateAsync(user);
            if (!success)
            {
                throw new AppException("An error occurred while adding new User!");
            }

            string link = "Https://";
            string content = $"<h2 style='color: #2C3E50;'>Account Information for Accessing the HTJ System</h2>";
            content = content + $"<p>Dear User,</p>";
            content = content + $"<p>You have successfully created an account on our system. Below are your login credentials:</p>";
            content = content + $"<p><b>Username: {user.UserName}</b></p>";
            content = content + $"<p><b>Password: {userCreate.Password}</b></p>";
            content = content + $"<p>If you did not request this account, please contact our support team immediately.</p>";
            content = content + $"<p>Best regards,<br><strong>HTJ Support</strong></p>";
            content = content + $"<p>Accress <a href=\"{link}\">HERE</a>.</p>";

            await _emailService.SendEmailAsync(user.Email, "HTJ - ACCOUNT INFORMATION FOR SOFTWARE ACCESS", content);
        }

        public async Task UpdateUserAsync(UserUpdate userUpdate)
        {
            if (userUpdate == null)
            {
                throw new AppException("UserUpdate can not be null!");
            }

            var user = await GetByIdAsync(userUpdate.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID '{userUpdate.Id}' does not exist.");
            }

            var item = _mapper.Map<Users>(userUpdate);
            IList<Users> existingUser = await GetListAsync(x => x.Deleted == false
                && (x.Email == user.Email || x.Phone == user.Phone || x.UserName == user.UserName),
                x => new Users { Id = x.Id, Phone = x.Phone, UserName = x.UserName });

            if (existingUser.Any(x => x.Phone == userUpdate.Phone) && !string.IsNullOrEmpty(userUpdate.Phone))
            {
                throw new Exception($"Phone number '{userUpdate.Phone}' already exist in system!");
            }

            if (existingUser.Any(x => x.UserName == userUpdate.UserName) && !string.IsNullOrEmpty(userUpdate.UserName))
            {
                throw new Exception($"Username '{userUpdate.UserName}' already exist in system!");
            }

            //item.UpdatedBy = LoginContext.Instance?.CurrentUser.UserId;

            bool success = await UpdateAsync(item);
            if (!success)
            {
                throw new AppException("An error occurred while updating the User!!");
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID '{id}' does not exist.");
            }

            bool success = await DeleteAsync(id);
            if (!success)
            {
                throw new AppException("An error occurred while deleting the User!");
            }
        }
    }
}
