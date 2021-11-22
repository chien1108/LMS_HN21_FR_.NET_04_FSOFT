using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Create(User newUser);

        Task<ServiceResponse<User>> Delete(User user);

        Task<ServiceResponse<User>> Update(User updateUser);

        Task<bool> IsExisted(string userName);

        Task<IList<User>> FindAll();

        Task<User> Find(string userName);

        Task<bool> SaveChange();
    }
}