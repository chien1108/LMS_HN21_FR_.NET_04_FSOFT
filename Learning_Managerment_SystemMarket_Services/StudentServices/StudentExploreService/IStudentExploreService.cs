using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService
{
    public interface IStudentExploreService
    {
        Task<ICollection<Course>> SearchCourse(string searchString);
        Task<IList<Course>> GetAllCourseIsActive();
    }
}