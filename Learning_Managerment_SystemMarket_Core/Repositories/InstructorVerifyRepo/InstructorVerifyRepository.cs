using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.InstructorVerifyRepo
{
    public class InstructorVerifyRepository : GenericRepository<InstructorVerify>, IInstructorVerifyRepository
    {
        private readonly LMSDbContext _context;

        public InstructorVerifyRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}