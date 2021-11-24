using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.SubCategoryViewModels;

namespace Learning_Managerment_SystemMarket_Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategortDetailsVm>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDetailsVm>().ReverseMap();
        }
    }
}
