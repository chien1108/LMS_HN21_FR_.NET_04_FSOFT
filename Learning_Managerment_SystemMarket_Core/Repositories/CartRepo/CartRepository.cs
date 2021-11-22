using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.CartRepo
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly LMSDbContext _context;

        public CartRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}