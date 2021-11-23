using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;

namespace Learning_Managerment_SystemMarket_Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseVm>()
                .ForMember(x => x.CategoryName, c => c.MapFrom(source => source.Category.CategoryName));
        }
    }
}
