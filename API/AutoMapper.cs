﻿using Application.Models.InventoryDetailModels;
using Application.Models.InventoryModels;
using Application.Models.JewelryModels;
using Application.Models.OrderModels;
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
            //User
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<UserCreate, User>().ReverseMap();
            CreateMap<UserUpdate, User>().ReverseMap();
            CreateMap<PagedList<UserModel>, PagedList<User>>().ReverseMap();

            //Order
            CreateMap<OrderModel, Order>()
                .ForMember(dest => dest.CustomerName, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<OrderCreate, Order>().ReverseMap();
            CreateMap<OrderUpdate, Order>().ReverseMap();
            CreateMap<PagedList<OrderModel>, PagedList<Order>>().ReverseMap();

            //Jewelry
            CreateMap<JewelryModel, Jewelry>().ReverseMap();
            CreateMap<JewelryCreate, Jewelry>().ReverseMap();
            CreateMap<JewelryUpdate, Jewelry>().ReverseMap();
            CreateMap<PagedList<JewelryModel>, PagedList<Jewelry>>().ReverseMap();

            //Inventory
            CreateMap<InventoryModel, Inventory>().ReverseMap();
            CreateMap<InventoryImportCreate, Inventory>().ReverseMap();
            CreateMap<InventoryExportCreate, Inventory>().ReverseMap();
            CreateMap<InventoryImportUpdate, Inventory>().ReverseMap();
            CreateMap<InventoryExportUpdate, Inventory>().ReverseMap();
            CreateMap<PagedList<InventoryModel>, PagedList<Inventory>>().ReverseMap();

            //Inventory Detail
            CreateMap<InventoryDetailsImportCreate, InventoryDetails>().ReverseMap();
            CreateMap<InventoryDetailsExportCreate, InventoryDetails>().ReverseMap();            
            CreateMap<InventoryDetailsImportUpdate, InventoryDetails>().ReverseMap();
            CreateMap<InventoryDetailsExportUpdate, InventoryDetails>().ReverseMap();
            CreateMap<InventoryDetailsModel, InventoryDetails>().ReverseMap();
        }
    }
}
