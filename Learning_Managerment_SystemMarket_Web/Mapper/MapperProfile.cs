using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
<<<<<<< HEAD
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.LanguageViewModels;
=======
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.SubCategoryViewModels;
>>>>>>> 4e256f905281aecf89be0eab0a5b82de7f044f7a
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserViewModels;

namespace Learning_Managerment_SystemMarket_Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategortDetailsVm>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDetailsVm>().ReverseMap();
            CreateMap<User, UserDetailsVm>().ReverseMap();
            CreateMap<Language, LanguageVM>().ReverseMap();
            
        }
    }
}
