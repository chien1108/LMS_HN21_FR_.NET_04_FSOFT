using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseRateService
{
    public interface IStudentCourseRateService
    {
        Task<IList<CourseRate>> FindAll(Expression<Func<CourseRate, bool>> expression = null,
                     Func<IQueryable<CourseRate>, IOrderedQueryable<CourseRate>> orderBy = null,
                     List<string> includes = null);
    }
}
