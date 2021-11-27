using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
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

        public async Task<ServiceResponse<SavedCourse>> CreateSavedCourse(SavedCourse savedCourse)
        {
            try
            {
                await _unitOfWork.Courses.CreateSavedCourse(savedCourse);
                if (await SaveChanges())
                {
                    return new ServiceResponse<SavedCourse> { Success = true, Message = "Add feedback Success" };
                }
                else
                {
                    return new ServiceResponse<SavedCourse> { Success = false, Message = "Error when create new savedCourse" };
                }
            }
            catch (Exception)
            {
                return new ServiceResponse<SavedCourse> { Success = false, Message = "Create fail" };
            }
        }

        public void Delete(SavedCourse savedCourse)
        {
            _unitOfWork.Courses.DeleteSaveCourse(savedCourse);
        }

        public void DeleteSaveCourses(int studentId)
        {
            _unitOfWork.Courses.DeleteSaveCourses(studentId);
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

        public async Task<bool> SaveChanges()
        {
            return await _unitOfWork.Save();
        }
    }
}