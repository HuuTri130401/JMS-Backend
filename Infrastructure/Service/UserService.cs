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

namespace Infrastructure.Service
{
    public class UserService : BaseDomainService<Users, UserSearch>, IUserService
    {
        private IConfiguration _configuaration;

        /*
         base(unitOfWork, mapper) gọi đến constructor của lớp cha (BaseDomainService), và mục đích của base là để truyền các dependency 
         từ UserService lên BaseDomainService. Điều này có nghĩa là UserService không cần khởi tạo lại IAppUnitOfWork và IMapper, mà chỉ 
         cần truyền chúng lên lớp cha để BaseDomainService xử lý.
         */
        public UserService(IConfiguration configuaration, IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _configuaration = configuaration;
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
    }
}
