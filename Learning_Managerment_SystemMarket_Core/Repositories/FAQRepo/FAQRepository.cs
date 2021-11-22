using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.FAQRepo
{
    public class FAQRepository : GenericRepository<FAQ>, IFAQRepository
    {
        private readonly LMSDbContext _context;

        public FAQRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}