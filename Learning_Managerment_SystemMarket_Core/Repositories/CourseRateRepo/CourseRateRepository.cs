using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CourseRateRepo
{
    public class CourseRateRepository : GenericRepository<CourseRate>, ICourseRateRepository
    {
        private readonly LMSDbContext _context;

        public CourseRateRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}