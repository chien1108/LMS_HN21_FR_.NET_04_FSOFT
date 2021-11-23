using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService
{
    public interface IStudentHomePageService
    {

        void Create(StudentHomePageVM studentHomeVM);

        void Delete(StudentHomePageVM studentHomeVM);

        void Update(StudentHomePageVM studentHomeVM);
        Task<bool> isExisted(Expression<Func<Course, bool>> expression = null);
        Task<IList<Course>> FindAllCourse(Expression<Func<Course, bool>> expression = null, Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null, List<string> includes = null);
        Task<Course> FindCourse(Expression<Func<Course, bool>> expression = null, List<string> includes = null);
        Task<IList<StudentHomePageVM>> GetAllCourseIsActive();
        Task<IList<CategoryDetailVM>> GetAllCategory();
        Task<CourseDetailVM> GetDetailsCourseById(int id);
        Task<IList<Course>> GetCourseByStudentId(int id);
        Task<bool> SaveChange();
        Task<ICollection<Course>> GetFeatureCourse(int size);
        Task<ICollection<Course>> GetNewestCourse(int size);
    }
}
