using Learning_Managerment_SystemMarket_ViewModels.Instructor.InstructorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.InsInstructorService
{
    public interface IInsInstructorService
    {
        Task<EarningView> GetBalanceInstructor(int id);
        Task<List<OrderVM>> GetOrdersByMonthAndYear(int month, int year, int id);
        Task<List<OrderVM>> GetAllOrders(int id);

        Task<OrderVM> GetOrderById(int id);
    }
}
