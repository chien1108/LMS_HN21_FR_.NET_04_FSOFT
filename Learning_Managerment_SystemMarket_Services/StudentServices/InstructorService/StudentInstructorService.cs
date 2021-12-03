using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.InstructorService
{
    public class StudentInstructorService : IStudentInstructorService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _map;

        public StudentInstructorService(IUnitOfWork unitOfWork, IMapper map)
        {
            this.unitOfWork = unitOfWork;
            _map = map;
        }

        public async Task<int> CountCourseByInstructorId(int id)
        {
            var listCourse = await unitOfWork.Courses.GetAll(x => x.InstructorId == id);
            int count = listCourse.Count();
            return count;
        }

        public async Task<Instructor> GetInstructorById(int id)
        {
            var instructor = await unitOfWork.Instructors.FindByCondition(x => x.Id == id);
            return instructor;
        }


    }
}
