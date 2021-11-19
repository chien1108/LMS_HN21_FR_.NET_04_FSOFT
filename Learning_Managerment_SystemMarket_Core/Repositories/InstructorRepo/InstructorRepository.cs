using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly LMSDbContext _context;

        public InstructorRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
