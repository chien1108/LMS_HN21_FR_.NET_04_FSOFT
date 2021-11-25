using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.ClaimRepo
{
    public class ClaimRepository : GenericRepository<Claim>, IClaimRepository
    {
        private readonly LMSDbContext _context;

        public ClaimRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
