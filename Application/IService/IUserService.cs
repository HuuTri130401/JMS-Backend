using Application.Models.UserModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Application.IService
{
    public interface IUserService : IGenericDomainService<Users, UserSearch>
    {
        Task<PagedList<UserModel>> GetPagedListUsers(UserSearch baseSearch);
        Task<UserModel> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(UserCreate userCreate);
        Task UpdateUserAsync(UserUpdate userUpdate);
        Task DeleteUserAsync(Guid id);
    }
}
