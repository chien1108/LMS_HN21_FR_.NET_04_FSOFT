using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseRepo
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<ICollection<Course>> GetCoursesByStudentId(int id); 
        Task<ICollection<Course>> GetCoursesByStudent(); 
        Task<ICollection<Course>> GetFeatureCourse(int size);
        Task<ICollection<Course>> GetNewestCourse(int size);
        Task<ICollection<Course>> SearchCourse(string searchString);
        Task<IList<Course>> GetAllCoursesIsActive();
        

    }
}