using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.FeedBackRepo
{
    public class FeedBackRepository : GenericRepository<FeedBack>, IFeedBackRepository
    {
        private readonly LMSDbContext _context;

        public FeedBackRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}