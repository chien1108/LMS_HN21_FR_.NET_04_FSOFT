using Learning_Managerment_SystemMarket_Core.Models;
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

        Task<IList<DisCountCourseVm>> GetAllDiscountCourses();

        Task<ViewCourseVm> GetViewCourses();

        Task<ServiceResponse<CourseVm>> ChangeStatusToDraft(int id);
        Task<ServiceResponse<CourseVm>> ChangeStatusToPending(int id);
        Task<ServiceResponse<CourseVm>> Delete(int id);
        Task<ServiceResponse<DisCountCourseVm>> ChangeStatus(int id);
        Task<ServiceResponse<DisCountCourseVm>> DeleteDiscount(int id);
        Task<ServiceResponse<DisCountCourseVm>> CreateDiscount(DisCountCourseVm entity);
        Task<ServiceResponse<DisCountCourseVm>> UpdateDiscount(DisCountCourseVm entity);

        Task<DisCountCourseVm> GetDiscountById(int id);

    }
}