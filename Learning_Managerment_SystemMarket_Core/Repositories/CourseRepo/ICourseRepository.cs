using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseRepo
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<IList<Course>> GetCoursesByStudentId(); 
        Task<ICollection<Course>> GetFeatureCourse(int size);
        Task<ICollection<Course>> GetNewestCourse(int size);
    }
}