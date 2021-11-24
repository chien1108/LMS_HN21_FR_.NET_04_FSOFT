using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
<<<<<<< HEAD
=======
using System;
>>>>>>> 4f3f97ba622514f16c292067d87b502bb5e81732

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseRepo
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly LMSDbContext _context;

        public CourseRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
        /// <summary>
        /// TamLV10 delete savecourse
        /// </summary>
        /// <param name="savedCourse"></param>
        public void DeleteSaveCourse(SavedCourse savedCourse)
        {
            _context.SavedCourses.Remove(savedCourse);
        }

<<<<<<< HEAD
        /// <summary>
        ///TamLV10 Find savedCourse by studentId and courseId
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns>SavedCourse</returns>
        public async Task<SavedCourse> FindSavedCourse(int studentId, int courseId)
=======
        public async Task<IList<Course>> GetAllCoursesIsActive()
        {
            var result = await _context.Courses.Include(q => q.Instructor).Include(q => q.SubCategory).Where(x => x.Status == StatusCourse.Active).ToListAsync();
            return result;
        }

        public async Task<ICollection<Course>> GetCoursesByStudent()
>>>>>>> 4f3f97ba622514f16c292067d87b502bb5e81732
        {
            var savedCourse = await _context.SavedCourses
                             .Include(x=>x.Course)
                            .FirstOrDefaultAsync(x => x.StudentId == studentId 
                            && x.CourseId == courseId);
            return savedCourse;
        }

        /// <summary>
        /// TamLV10 GetCoursesByStudentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<ICollection<SavedCourse>> GetCoursesByStudentId(int studentId)
        {
            var savedCourses = await _context.SavedCourses
                .Include(x=>x.Course)
                .Where(x=>x.StudentId==studentId)
                .ToListAsync();
            return savedCourses;
        }
        public async Task<ICollection<Course>> GetFeatureCourse(int size)
        {
          
<<<<<<< HEAD
            var course = await _context.Courses
                .OrderByDescending(x => x.Likes)
                .Take(size)
                .ToListAsync();
=======
            var course = await _context.Courses.Include(q => q.Instructor).Include(q => q.SubCategory).OrderByDescending(x => x.Likes).Take(size).ToListAsync();
>>>>>>> 4f3f97ba622514f16c292067d87b502bb5e81732
            return course;
        }

        public async Task<ICollection<Course>> GetNewestCourse(int size)
        {
<<<<<<< HEAD
            var course = await _context.Courses
                .OrderByDescending(x => x.ModifiedDate)
                .Take(size)
                .ToListAsync();
=======
            var course = await _context.Courses.Include(q => q.Instructor).Include(q => q.SubCategory).OrderByDescending(x => x.ModifiedDate).Take(size).ToListAsync();
            return course;
        }

        public async Task<ICollection<Course>> SearchCourse(string searchString)
        {
            
            var course = await _context.Courses.Include(q => q.Instructor).Include(q => q.SubCategory).Where(x => x.Status == StatusCourse.Active).ToListAsync();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                course = course.Where(x => x.Title.Contains(searchString)).ToList();
            }
          
>>>>>>> 4f3f97ba622514f16c292067d87b502bb5e81732
            return course;
            
        }

      
    }
}