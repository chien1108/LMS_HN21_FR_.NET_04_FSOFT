using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> CountStudentByInstructorId(int id)
        {
            var subScriptions = await unitOfWork.Context.SubScriptions.Where(s => s.InstructorId == id).ToListAsync();
            return subScriptions.Count;
        }

        public async Task<IList<Course>> GetCourseByInstructorId(int id)
        {
            var list = await unitOfWork.Courses.GetAll(x => x.InstructorId == id, includes: new List<string> { "Category","SubCategory" });
            return list;
        }
        
        public async Task<IList<Instructor>> GetInstructorByStudentId(int id)
        {
            var subScriptions = await unitOfWork.Context.SubScriptions.Where(s => s.StudentId == id).ToListAsync();
            var instructors = new List<Instructor>();
            foreach (var item in subScriptions)
            {
                var instructor = await unitOfWork.Instructors.FindByCondition(i => i.Id == item.InstructorId);
                instructors.Add(instructor);
            }
            return instructors;
        }

        public async Task<Instructor> GetInstructorById(int id)
        {
            var instructor = await unitOfWork.Instructors.FindByCondition(x => x.Id == id);
            return instructor;
        }

        public async Task<IList<Instructor>> GetAllInstructor()
        {
            return await unitOfWork.Instructors.GetAll();
        }

        public async Task<ICollection<Instructor>> SearchInstructorByStudentId(string searchString, int studentId)
        {
            var instructor = await GetInstructorByStudentId(studentId);
            if (!String.IsNullOrEmpty(searchString))
            {
                instructor = instructor.Where(x => x.InstructorName.Contains(searchString)).ToList();
            }
            return instructor;
        }
    }
}
