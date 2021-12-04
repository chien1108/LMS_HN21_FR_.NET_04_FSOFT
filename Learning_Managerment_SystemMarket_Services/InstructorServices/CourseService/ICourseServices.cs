using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.ResponseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService
{
    public interface ICourseServices
    {
        Task<IList<CourseVm>> GetAllDraftCourses(int id);

        Task<IList<CourseVm>> GetAllCourses(int id);

        Task<IList<CourseVm>> GetAllUpcomingCourses(int id);

        Task<ResponseResult> CreateCourse(CreateCourseVm model, List<CreateCourseContentVm> createCourseContentVms, List<CreateLectureVm> createLectureVms, int instructorId);

        Task<IList<DisCountCourseVm>> GetAllDiscountCourses(int id);

        Task<ViewCourseVm> GetViewCourses(int id);

        Task<ServiceResponse<CourseVm>> ChangeStatusToDraft(int id);
        Task<ServiceResponse<CourseVm>> ChangeStatusToPending(int id);
        Task<ServiceResponse<CourseVm>> Delete(int id);
        Task<ServiceResponse<DisCountCourseVm>> ChangeStatus(int id);
        Task<ServiceResponse<DisCountCourseVm>> DeleteDiscount(int id);
        Task<ServiceResponse<DisCountCourseVm>> CreateDiscount(DisCountCourseVm entity);
        Task<ServiceResponse<DisCountCourseVm>> UpdateDiscount(DisCountCourseVm entity);
        Task<ServiceResponse<DisCountCourseVm>> ClearDiscountExpire();

        Task<DisCountCourseVm> GetDiscountById(int id);
        Task<CourseVm> GetCourseById(int id);

        Task<IList<CourseVm>> GetAllCourseWaitApprove(); Task<bool> IsExisted(Expression<Func<Course, bool>> expression = null);
        Task<Course> Find(Expression<Func<Course, bool>> expression = null,
                           List<string> includes = null);
        Task<IList<Course>> FindAll(Expression<Func<Course, bool>> expression = null,
                             Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null,
                             List<string> includes = null);
        Task<ServiceResponse<Course>> Update(CourseVm updateCourse);
        Task<bool> SaveChange();

    }
}
