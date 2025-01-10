using Application.Models.JewelryModels;
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
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<UserCreate, User>().ReverseMap();
            CreateMap<UserUpdate, User>().ReverseMap();
            CreateMap<PagedList<UserModel>, PagedList<User>>().ReverseMap();

            //Jewelry
            CreateMap<JewelryModel, Jewelry>().ReverseMap();
            CreateMap<JewelryCreate, Jewelry>().ReverseMap();
            CreateMap<JewelryUpdate, Jewelry>().ReverseMap();
            CreateMap<PagedList<JewelryModel>, PagedList<Jewelry>>().ReverseMap();
        }
    }
}
