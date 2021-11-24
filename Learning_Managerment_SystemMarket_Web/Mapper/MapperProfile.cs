﻿using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserViewModels;

namespace Learning_Managerment_SystemMarket_Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategortDetailsVm>().ReverseMap();
            CreateMap<User, UserDetailsVm>().ReverseMap();
        }
    }
}
