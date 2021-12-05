using AutoMapper;
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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public CartService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }
        public async Task<ServiceResponse<Cart>> Create(Cart cart)
        {
            try
            {
                await _unitOfWork.Carts.Create(cart);
                var success = await SaveChange();
                if (success)
                {
                    return new ServiceResponse<Cart> { Success = true, Message = "Add Cart Success" };
                }
                else
                {
                    return new ServiceResponse<Cart> { Success = false, Message = "Error when create new Cart" };
                }
            }
            catch (Exception)
            {
                return new ServiceResponse<Cart> { Success = false, Message = "Create fail" };
            }
        }

        public async Task<ServiceResponse<Cart>> Delete(CartItemVM cartVM)
        {
            try
            {
                if (cartVM != null)
                {
                    var cart = await _unitOfWork.Carts.FindByCondition(
                        expression: c => c.StudentId == cartVM.StudentId &&
                        c.CourseId == cartVM.CourseId);
                    _unitOfWork.Carts.Delete(cart);
                    var success = await SaveChange();
                    if (!success)
                    {
                        return new ServiceResponse<Cart> { Success = false, Message = "Error when delete Cart" };
                    }
                    return new ServiceResponse<Cart> { Success = true, Message = "Delete Cart Success" };
                }
                else
                {
                    return new ServiceResponse<Cart> { Success = false, Message = "Not Found Cart" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<Cart> { Success = false, Message = ex.Message };
            }
        }

        public async Task<CartItemVM> Find(Expression<Func<Cart, bool>> expression = null,
            List<string> includes = null)
        {
            var cart = await _unitOfWork.Carts.FindByCondition(expression, includes);
            return _map.Map<CartItemVM>(cart);
        }

        public async Task<ICollection<CartItemVM>> FindAll(Expression<Func<Cart, bool>> expression = null,
            Func<IQueryable<Cart>, IOrderedQueryable<Cart>> orderBy = null, 
            List<string> includes = null)
        {
            var carts = await _unitOfWork.Carts.GetAll(expression, orderBy, includes);
            return _map.Map<ICollection<CartItemVM>>(carts);
        }

        public async Task<ServiceResponse<Cart>> Payment(int studentId)
        {
            try
            {
                var carts = await _unitOfWork.Carts.GetAll(
                    expression: c => c.StudentId == studentId);
                var count = carts.Count;
                foreach (var item in carts)
                {
                    var course =await _unitOfWork.Courses.FindByCondition(c => c.Id == item.CourseId);
                    var order = new Order
                    {
                        StudentId = studentId,
                        CourseId = item.CourseId,
                        CreatedDate = DateTime.Now,
                        Price = course.Price
                    };

                    await _unitOfWork.Orders.Create(order);
                    var successCreate = await SaveChange();
                    if(!successCreate)
                        return new ServiceResponse<Cart> { Success = false, Message = "Payment Cart Error" };

                    _unitOfWork.Carts.Delete(item);
                    var sucessDelete = await SaveChange();
                    if (sucessDelete)
                        count--;
                    else
                        return new ServiceResponse<Cart> { Success = false, Message = "Payment Cart Error" };
                }
                return count<1 ? new ServiceResponse<Cart> { Success = true, Message = "Payment Cart Success" }
                : new ServiceResponse<Cart> { Success = false, Message = "Payment Cart Error" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Cart> { Success = false, Message = ex.Message };
            }
        }
        public async Task<bool> SaveChange()
        {
            return await _unitOfWork.Save();
        }
    }
}
