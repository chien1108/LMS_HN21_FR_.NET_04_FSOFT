using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.OrderRepo
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly LMSDbContext _context;

        public OrderRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders(int id)
        {
            var orders = await _context.Orders.Include(x => x.Course).ThenInclude(x => x.Instructor).Where(x => x.Course.InstructorId == id).ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetOrdersByMonthAndYear(int month, int year, int id)
        {
            var orders = await _context.Orders.Include(x => x.Course).ThenInclude(x => x.Instructor).Where(x => x.CreatedDate.Month == month && x.CreatedDate.Year == year && x.Course.InstructorId == id).ToListAsync();
            return orders;
        }

        public decimal SumOrderByInstructorId(int id)
        {
            var sum = _context.Orders.Include(x => x.Course).ThenInclude(x => x.Instructor).Where(x => x.Course.InstructorId == id).Sum(x => x.Price);
            return sum;
        }
    }
}