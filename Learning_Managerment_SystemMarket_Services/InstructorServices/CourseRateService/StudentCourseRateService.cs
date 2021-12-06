using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseRateService
{
    public class StudentCourseRateService : IStudentCourseRateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentCourseRateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<CourseRate>> FindAll(Expression<Func<CourseRate, bool>> expression = null, Func<IQueryable<CourseRate>, IOrderedQueryable<CourseRate>> orderBy = null, List<string> includes = null)
                => await _unitOfWork.CourseRates.GetAll(expression, orderBy, includes);
    }
}
