using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService
{
    public class StudentExploreService : IStudentExploreService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _map;

        public StudentExploreService(IUnitOfWork unitOfWork, IMapper map)
        {
            this.unitOfWork = unitOfWork;
            _map = map;
        }

        public async Task<IList<Course>> GetAllCourseIsActive()
        {
            var listCourse = await unitOfWork.Courses.GetAll(x => x.Status == StatusCourse.Active);
            return listCourse;
        }

        public async Task<ICollection<Course>> SearchCourse(string searchString)
        {
            var course = await GetAllCourseIsActive();
            List<Course> courses;
            if (!String.IsNullOrEmpty(searchString))
            {
                courses = course.Where(x => x.Title == searchString).ToList();
                return courses;
            }
            return null;
            
        }
    }
}
