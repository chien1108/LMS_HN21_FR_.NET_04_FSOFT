using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<Cart>> Create(Cart cart);
        Task<ServiceResponse<Cart>> Delete(Cart cart);
    }
}
