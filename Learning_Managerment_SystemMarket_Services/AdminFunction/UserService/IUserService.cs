using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Create(User newUser, string password);

        Task<ServiceResponse<User>> Delete(User user);

        Task<ServiceResponse<User>> Update(User updateUser);

        Task<bool> IsExisted(string userName);

        Task<IList<User>> FindAll();

        Task<IList<User>> FindAll(Expression<Func<User, bool>> expression = null);

        Task<User> Find(Expression<Func<User, bool>> expression);

        Task<ICollection<string>> GetUserRoles(User user);

        Task<ServiceResponse<User>> RemoveFromRoles(User user, IEnumerable<string> roles);

        Task<ServiceResponse<User>> AddToRoles(User user, IEnumerable<string> roles);

        Task<bool> SaveChange();
    }
}