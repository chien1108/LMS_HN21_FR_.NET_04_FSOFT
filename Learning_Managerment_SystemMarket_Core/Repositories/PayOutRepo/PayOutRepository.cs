using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.PayOutRepo
{
    public class PayOutRepository : GenericRepository<PayOut>, IPayOutRepository
    {
        private readonly LMSDbContext _context;

        public PayOutRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}