using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.LectureRepo
{
    public class LectureRepository : GenericRepository<Lecture>, ILectureRepository
    {
        private readonly LMSDbContext _context;

        public LectureRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}