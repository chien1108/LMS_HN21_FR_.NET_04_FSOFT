using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.LanguageViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.RoleViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.SubCategoryViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserViewModels;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CategoryViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LanguageViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.SubCategoryViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.DashboardViewModels;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.InstructorViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.OrderViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseRateViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.StudentViewModel;
using System.Collections.Generic;

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
            CreateMap<SavedCourse, SavedCoursesVM>().ReverseMap();
            CreateMap<Category, CategoryDetailVM>().ReverseMap();
            CreateMap<SubScription, SubScriptionVM>().ReverseMap();
            CreateMap<Course, CourseVm>()
                .ForMember(x => x.CategoryName, c => c.MapFrom(source => source.Category.CategoryName)).ReverseMap();
            CreateMap<SpecialDiscount, DisCountCourseVm>()
                .ForMember(x => x.CourseName, c => c.MapFrom(source => source.Course.Title)).ReverseMap();
            CreateMap<Course, CreateCourseVm>().ReverseMap();
            CreateMap<Order, OrderVM>()
                .ForMember(x => x.CourseName, c => c.MapFrom(source => source.Course.Title)).ReverseMap();
            CreateMap<Lecture, CreateLectureVm>().ReverseMap();
            CreateMap<CourseContent, CreateCourseContentVm>().ReverseMap();
            CreateMap<Category, CategoryVm>().ReverseMap();
            CreateMap<SubCategory, SubCategoryVm>().ReverseMap();
            CreateMap<Language, LanguageVm>().ReverseMap();
            CreateMap<Instructor, InstructorVm>().ReverseMap();
            CreateMap<Instructor, CardInstructorVM>().ReverseMap();
            CreateMap<Course, CourseDetailVM>().ReverseMap();
            CreateMap<Course, CardCourseVM>().ReverseMap();
            CreateMap<Order, OrderVm>().ReverseMap();
            CreateMap<CartItemVM, Cart>().ReverseMap();
            CreateMap<CourseRateVm, CourseRate>().ReverseMap();
            CreateMap<StudentVm, Student>().ReverseMap();
            CreateMap<Course, SubmitCoursesVM>().ReverseMap();
            CreateMap<List<Course>, List<LastSellCoursesVM>>().ReverseMap();
            CreateMap<User, UpdateVM>().ReverseMap();
          
        }
    }
}
