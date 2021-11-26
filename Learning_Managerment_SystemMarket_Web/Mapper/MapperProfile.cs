using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CategoryViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LanguageViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.SubCategoryViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.DashboardViewModels;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;

namespace Learning_Managerment_SystemMarket_Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseVm>()
                .ForMember(x => x.CategoryName, c => c.MapFrom(source => source.Category.CategoryName));
            CreateMap<Course, CreateCourseVm>().ReverseMap();
            CreateMap<Lecture, CreateLectureVm>().ReverseMap();
            CreateMap<CourseContent, CreateCourseContentVm>().ReverseMap();

            CreateMap<Category, CategoryVm>().ReverseMap();
            CreateMap<SubCategory, SubCategoryVm>().ReverseMap();
            CreateMap<Language, LanguageVm>().ReverseMap();
        }
    }
}
