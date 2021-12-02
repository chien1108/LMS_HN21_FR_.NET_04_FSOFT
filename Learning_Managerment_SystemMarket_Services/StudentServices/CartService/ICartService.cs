using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<Cart>> Create(Cart cart);
        Task<ServiceResponse<Cart>> Delete(CartItemVM cart);
        Task<ServiceResponse<Cart>> Payment(int studentId);
        Task<CartItemVM> Find(Expression<Func<Cart, bool>> expression = null, List<string> includes = null);
        Task<ICollection<CartItemVM>> FindAll(
            Expression<Func<Cart, bool>> expression = null, 
            Func<IQueryable<Cart>, IOrderedQueryable<Cart>> orderBy = null,
            List<string> includes = null);
    }
}
