using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
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
                if (await SaveChange())
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

        public async Task<ServiceResponse<Cart>> Delete(Cart cart)
        {
            try
            {
                var cartItem = await Find(x => x.StudentId == cart.StudentId && x.CourseId == cart.CourseId);
                if (cartItem != null)
                {
                    _unitOfWork.Carts.Delete(cart);
                    if (!await SaveChange())
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

        public async Task<Cart> Find(Expression<Func<Cart, bool>> expression = null, List<string> includes = null)
            => await _unitOfWork.Carts.FindByCondition(expression, includes);

        public async Task<ICollection<Cart>> FindAll(Expression<Func<Cart, bool>> expression = null, Func<IQueryable<Cart>, IOrderedQueryable<Cart>> orderBy = null, List<string> includes = null)
            => await _unitOfWork.Carts.GetAll(expression, orderBy, includes);

        public async Task<bool> SaveChange()
        {
            return await _unitOfWork.Save();
        }
    }
}
