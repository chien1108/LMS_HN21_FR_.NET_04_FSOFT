using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CategoryViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LanguageViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.SubCategoryViewModel;

namespace Learning_Managerment_SystemMarket_Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseVm>()
                .ForMember(x => x.CategoryName, c => c.MapFrom(source => source.Category.CategoryName)).ReverseMap();
            CreateMap<SpecialDiscount, DisCountCourseVm>()
                .ForMember(x => x.CourseName, c => c.MapFrom(source => source.Course.Title)).ReverseMap();
            CreateMap<Course, CreateCourseVm>().ReverseMap();
            CreateMap<Category, CategoryVm>().ReverseMap();
            CreateMap<SubCategory, SubCategoryVm>().ReverseMap();
            CreateMap<Language, LanguageVm>().ReverseMap();
        }
    }
}
