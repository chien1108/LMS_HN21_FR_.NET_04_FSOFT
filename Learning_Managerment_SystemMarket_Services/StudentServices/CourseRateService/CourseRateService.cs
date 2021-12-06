using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.CourseRateService
{
    public class CourseRateService : ICourseRateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public CourseRateService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }

        public async Task<double> AvgCourseRate(int courseId)
        {
            var courseRates = await _unitOfWork.CourseRates.GetAll(c => c.CourseId == courseId);
            return Math.Round(courseRates.Average(c=>c.Star), 1);
        }

        public async Task<int> CountStudentRate(int courseId)
        {
            var courseRates = await _unitOfWork.CourseRates.GetAll(c => c.CourseId == courseId);
            return courseRates.Count;
        }

        public async Task<ServiceResponse<CourseRateVM>> CreateCourseRate(CourseRateVM courseRate, int studentId)
        {
            try
            {
                var model = _map.Map<CourseRate>(courseRate);
                model.StudentId = studentId;
                model.CreatedDate = DateTime.Now;
                var existingCourseRate = await _unitOfWork.CourseRates.FindByCondition(
                    expression: c => c.CourseId == model.CourseId 
                    && c.StudentId == model.StudentId);
                if(existingCourseRate == null)
                {
                    await _unitOfWork.CourseRates.Create(model);
                    var success = await _unitOfWork.Save();
                    if (success)
                    {
                        return new ServiceResponse<CourseRateVM> { Success = true, Message = "Rate successful" };
                    }
                    else
                        return new ServiceResponse<CourseRateVM> { Success = false, Message = "Something was wrong" };
                }
                else
                {
                    _unitOfWork.CourseRates.Delete(existingCourseRate);
                    var deleteSuccess = await _unitOfWork.Save();
                    if (deleteSuccess)
                    {
                        await _unitOfWork.CourseRates.Create(model);
                        var success = await _unitOfWork.Save();
                        if (success)
                        {
                            return new ServiceResponse<CourseRateVM> { Success = true, Message = "Rate successful" };
                        }
                        else
                            return new ServiceResponse<CourseRateVM> { Success = false, Message = "Something was wrong" };
                    }
                    else return new ServiceResponse<CourseRateVM> { Success = false, Message = "Something was wrong" };
                }
            }
            catch (Exception)
            {
                return new ServiceResponse<CourseRateVM> { Success = false, Message = "Something was wrong" };
            }
        }
    }
}