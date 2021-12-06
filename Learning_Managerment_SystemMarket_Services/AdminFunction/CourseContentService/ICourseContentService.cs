using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.CourseContentService
{
    public interface ICourseContentService
    {
        Task<CourseContent> Find(Expression<Func<CourseContent, bool>> expression = null, List<string> includes = null);
    }
}
