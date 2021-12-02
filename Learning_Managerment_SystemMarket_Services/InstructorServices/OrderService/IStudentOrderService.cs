using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.OrderService
{
    public interface IStudentOrderService
    {
        Task<IEnumerable<OrderVm>> FindAll(Expression<Func<Order, bool>> expression = null,
                         Func<IQueryable<Order>,
                         IOrderedQueryable<Order>> orderBy = null,
                         List<string> includes = null);
    }
}
