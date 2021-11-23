using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<Role>> Create(Role newRole);

        Task<ServiceResponse<Role>> Delete(Role role);

        Task<ServiceResponse<Role>> Update(Role updateRole);

        Task<bool> IsExisted(string roleName);

        Task<IList<Role>> FindAll();

        Task<Role> Find(string roleName);

        Task<bool> SaveChange();
    }
}