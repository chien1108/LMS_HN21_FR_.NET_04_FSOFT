using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService
{
    /// <summary>
    /// TamLV10 
    /// </summary>
    public class SavedCourseService : ISavedCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public SavedCourseService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }

        public void Delete(SavedCourse savedCourse)
        {
            _unitOfWork.Courses.DeleteSaveCourse(savedCourse);
        }

        public async Task<SavedCourse> FindSavedCourse(int studentId,int courseId)
        {
            var savedCourse = await _unitOfWork.Courses.FindSavedCourse(studentId, courseId);
            return savedCourse;
        }

        public async Task<ICollection<SavedCourse>> GetSavedCoursesByStudentId(int studentId)
        {
            try
            {
                var results = await _unitOfWork.Courses.GetCoursesByStudentId(studentId);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}