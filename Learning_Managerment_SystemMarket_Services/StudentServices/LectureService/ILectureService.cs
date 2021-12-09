using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.LectureService
{
    public interface ILectureService
    {
        Task<bool> IsExisted(Expression<Func<Lecture, bool>> expression = null);
        Task<ICollection<Lecture>> FindAll(Expression<Func<Lecture,
                                bool>> expression = null,
                                Func<IQueryable<Lecture>,
                               IOrderedQueryable<Lecture>> orderBy = null,
                                List<string> includes = null);
        Task<Lecture> Find(Expression<Func<Lecture, bool>> expression = null, List<string> includes = null);
        Task<ICollection<CourseContent>> GetCourseContentByCourseId(int courseId);
        Task<bool> SaveChange();
    }
}