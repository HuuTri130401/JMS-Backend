using Application.Models.UserModels;
using AutoMapper;
using Domain.Entities;
using Utilities;

namespace API
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            //Người dùng
            CreateMap<UserModel, Users>().ReverseMap();
            CreateMap<UserCreate, Users>().ReverseMap();
            CreateMap<UserUpdate, Users>().ReverseMap();
            CreateMap<PagedList<UserModel>, PagedList<Users>>().ReverseMap();
        }
    }
}
