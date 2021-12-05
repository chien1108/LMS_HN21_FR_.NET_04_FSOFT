using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.OrderService
{
    public interface IOrderService
    {
        Task<Order> Find(Expression<Func<Order, bool>> expression = null,
            List<string> includes = null);
        Task<ICollection<Order>> FindAll(
            Expression<Func<Order, bool>> expression = null,
            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
            List<string> includes = null);
    }
}