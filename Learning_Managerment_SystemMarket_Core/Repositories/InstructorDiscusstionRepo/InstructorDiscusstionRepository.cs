using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.InstructorDiscusstionRepo
{
    public class InstructorDiscusstionRepository : GenericRepository<InstructorDiscusstion>, IInstructorDiscusstionRepository
    {
        private readonly LMSDbContext _context;

        public InstructorDiscusstionRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}