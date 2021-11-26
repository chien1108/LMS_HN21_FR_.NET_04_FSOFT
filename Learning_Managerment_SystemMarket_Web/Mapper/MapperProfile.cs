using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.LanguageViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.RoleViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.SubCategoryViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserViewModels;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;

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
            CreateMap<Role,RoleVM>().ReverseMap();

            CreateMap<Course, StudentHomePageVM>().ReverseMap();
            CreateMap<Course, CourseDetailVM>().ReverseMap();
            CreateMap<Category, CategoryDetailVM>().ReverseMap();
        }
    }
}
