using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.CourseService
{
    public interface ICourseService
    {
        Task<IList<Course>> FindAll(Expression<Func<Course, bool>> expression = null,
                             Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null,
                             List<string> includes = null);
    }
}
