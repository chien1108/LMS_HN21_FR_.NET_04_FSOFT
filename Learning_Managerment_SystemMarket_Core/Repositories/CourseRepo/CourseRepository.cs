using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseRepo
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly LMSDbContext _context;

        public CourseRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }


        public Task<IList<Course>> GetCoursesByStudentId()
        {
            throw new System.NotImplementedException();
        }
        public async Task<ICollection<Course>> GetFeatureCourse(int size)
        {
            var course = await _context.Courses.OrderByDescending(x => x.Likes).Take(size).ToListAsync();
            return course;
        }

        public async Task<ICollection<Course>> GetNewestCourse(int size)
        {
            var course = await _context.Courses.OrderByDescending(x => x.ModifiedDate).Take(size).ToListAsync();
            return course;
        }
    }
}