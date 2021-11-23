using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService
{
    public interface ICourseServices
    {
        Task<IList<CourseVm>> GetAllDraftCourses();

        Task<IList<CourseVm>> GetAllCourses();

        Task<IList<CourseVm>> GetAllUpcomingCourses();
    }
}