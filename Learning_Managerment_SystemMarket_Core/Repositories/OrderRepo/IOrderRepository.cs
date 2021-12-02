using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.OrderRepo
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        decimal SumOrderByInstructorId(int id);
        Task<List<Order>> GetOrdersByMonthAndYear(int month, int year, int id);
        Task<List<Order>> GetAllOrders(int id);
    }
}