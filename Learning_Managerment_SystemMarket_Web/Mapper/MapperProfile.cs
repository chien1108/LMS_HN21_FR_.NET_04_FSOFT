using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
<<<<<<< HEAD
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.SubCategoryViewModels;
=======
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserViewModels;
>>>>>>> 5f2735449fb9b9547ac9584e975be7ec8ba58ab7

namespace Learning_Managerment_SystemMarket_Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategortDetailsVm>().ReverseMap();
<<<<<<< HEAD
            CreateMap<SubCategory, SubCategoryDetailsVm>().ReverseMap();
=======
            CreateMap<User, UserDetailsVm>().ReverseMap();
>>>>>>> 5f2735449fb9b9547ac9584e975be7ec8ba58ab7
        }
    }
}
