using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseRepo
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
<<<<<<< HEAD
        Task<IList<Course>> GetCoursesByStudentId(); 
=======
        Task<ICollection<Course>> GetFeatureCourse(int size);
        Task<ICollection<Course>> GetNewestCourse(int size);
>>>>>>> 5835e0a7621e12a39d9e11c90864fa7e75c1ac0c
    }
}