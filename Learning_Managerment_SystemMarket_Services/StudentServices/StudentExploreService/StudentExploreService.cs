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
            var listCourse = await unitOfWork.Courses.GetAllCoursesIsActive();
            return listCourse;
        }

        public async Task<ICollection<Course>> SearchCourse(string searchString)
        {
            var result = await unitOfWork.Courses.SearchCourse(searchString);
            return result;
            
        }
    }
}
