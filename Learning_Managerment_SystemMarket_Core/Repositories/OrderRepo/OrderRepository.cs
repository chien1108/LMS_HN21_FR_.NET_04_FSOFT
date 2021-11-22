using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.OrderRepo
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly LMSDbContext _context;

        public OrderRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}