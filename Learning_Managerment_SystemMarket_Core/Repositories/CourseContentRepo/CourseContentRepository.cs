using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseContentRepo
{
    public class CourseContentRepository : GenericRepository<CourseContent>, ICourseContentRepository
    {
        private readonly LMSDbContext _context;

        public CourseContentRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}