using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.InstructorService
{
    public interface IStudentInstructorService 
    {
        Task<Instructor> GetInstructorById(int id);
        Task<int> CountCourseByInstructorId(int id);
        Task<IList<Course>> GetCourseByInstructorId(int id);
    }
}
