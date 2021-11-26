using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.ResponseResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService
{
    public interface ICourseServices
    {
        Task<IList<CourseVm>> GetAllDraftCourses();

        Task<IList<CourseVm>> GetAllCourses();

        Task<IList<CourseVm>> GetAllUpcomingCourses();

        Task<ResponseResult> CreateCourse(CreateCourseVm model, List<CreateCourseContentVm> createCourseContentVms, List<CreateLectureVm> createLectureVms);
    }
}