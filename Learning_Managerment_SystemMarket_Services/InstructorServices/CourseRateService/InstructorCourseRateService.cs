using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseRateViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseRateService
{
    public class InstructorCourseRateService : IInstructorCourseRateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstructorCourseRateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<CourseRateVm>> GetCourseRates(Expression<Func<CourseRate, bool>> expression = null, List<string> includes = null)
        {
            var courseRates = await _unitOfWork.CourseRates.GetAll(expression, null, includes);

            return _mapper.Map<ICollection<CourseRateVm>>(courseRates);
        }
    }
}