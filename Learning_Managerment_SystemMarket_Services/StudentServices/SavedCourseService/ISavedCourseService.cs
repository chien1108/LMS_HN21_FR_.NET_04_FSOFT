using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService
{
    /// <summary>
    /// TamLV10
    /// </summary>
    public interface ISavedCourseService
    {
        Task<ServiceResponse<SavedCourse>> CreateSavedCourse(SavedCourse savedCourse);
        void Delete(SavedCourse savedCourse);
        void DeleteSaveCourses(int studentId);
        Task<bool> SaveChanges();
        Task<SavedCourse> FindSavedCourse(int studentId, int courseId);
        Task<ICollection<SavedCourse>> GetSavedCoursesByStudentId(int studentId);
    }
}
