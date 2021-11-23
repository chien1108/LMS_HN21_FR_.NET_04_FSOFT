using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;
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

        public async Task<List<Course>> GetAllDraftCourses()
        {
            return await _context.Courses.Include(x => x.CourseContent).Where(x => x.Status == StatusCourse.Draft).ToListAsync();
        }

        public async Task<List<Course>> GetAllUpcomingCourses()
        {
            return await _context.Courses.Include(x => x.CourseContent).Where(x => x.Status == StatusCourse.WaitForApproced).ToListAsync();
        }
    }
}