using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseRateViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseRateService
{
    public interface IInstructorCourseRateService
    {
        Task<ICollection<CourseRateVm>> GetCourseRates(Expression<Func<CourseRate, bool>> expression = null, List<string> includes = null);
    }
}