using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseRepo
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<ICollection<SavedCourse>> GetCoursesByStudentId(int id); 
        Task<ICollection<Course>> GetFeatureCourse(int size);
        Task<ICollection<Course>> GetNewestCourse(int size);
        Task<SavedCourse> FindSavedCourse(int studentId, int courseId);
        Task CreateSavedCourse(SavedCourse savedCourse);
        void DeleteSaveCourse(SavedCourse savedCourse);
        void DeleteSaveCourses(int studentId);
        Task<ICollection<Course>> SearchCourse(string searchString);
        Task<IList<Course>> GetAllCoursesIsActive();
        

    }
}