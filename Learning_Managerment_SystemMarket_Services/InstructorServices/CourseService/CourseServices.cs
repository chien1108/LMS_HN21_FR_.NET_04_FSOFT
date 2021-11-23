using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService
{
    public class CourseServices : ICourseServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<CourseVm>> GetAllCourses()
        {
            var courses = await _unitOfWork.Courses.GetAll(includes: new List<string> { "Category" });
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach(var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }

        public async Task<IList<CourseVm>> GetAllDraftCourses()
        {
            var courses = await _unitOfWork.Courses.GetAll(expression: x => x.Status == StatusCourse.Draft, includes: new List<string> { "Category" });
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach (var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }

        public async Task<IList<CourseVm>> GetAllUpcomingCourses()
        {
            var courses = await _unitOfWork.Courses.GetAll(expression: x => x.Status == StatusCourse.WaitForApproced, includes: new List<string> { "Category" });
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach (var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }
    }
}
