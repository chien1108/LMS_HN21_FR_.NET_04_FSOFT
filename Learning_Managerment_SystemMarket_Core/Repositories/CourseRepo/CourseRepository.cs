using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseRepo
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly LMSDbContext _context;

        public CourseRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Course>> GetCoursesByStudent()
        {
            var courses = await _context.Courses
                .Include(c => c.CourseRates)
                .ToListAsync();
            return courses;
        }

        public async Task<ICollection<Course>> GetCoursesByStudentId(int id)
        {
            var courses = await _context.Courses
                .Include(c => c.CourseRates)
                .ThenInclude(c => c.StudentId == id)
                .ToListAsync();
            return courses;
        }
        public async Task<ICollection<Course>> GetFeatureCourse(int size)
        {
          
            var course = await _context.Courses.Include(q => q.Instructor).Include(q => q.SubCategory).OrderByDescending(x => x.Likes).Take(size).ToListAsync();
            return course;
        }

        public async Task<ICollection<Course>> GetNewestCourse(int size)
        {
            var course = await _context.Courses.Include(q => q.Instructor).Include(q => q.SubCategory).OrderByDescending(x => x.ModifiedDate).Take(size).ToListAsync();
            return course;
        }

        public async Task<ICollection<Course>> SearchCourse(string searchString)
        {
            var course = await _context.Courses.Include(q => q.Instructor).Include(q => q.SubCategory).Where(x => x.Status == StatusCourse.Active).ToListAsync();
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