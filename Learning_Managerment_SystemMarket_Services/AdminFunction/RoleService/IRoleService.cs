using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<Role>> Create(Role newRole,List<Claim> claims);

        Task<ServiceResponse<Role>> Delete(Role role);

        Task<ServiceResponse<Role>> Update(Role updateRole,List<Claim> newClaims,List<Claim> removeClaims);

        Task<bool> IsExisted(string roleName);

        Task<IList<Role>> FindAll();

        Task<Role> Find(Expression<Func<Role, bool>> expression);
        Task<bool> SaveChange();
    }
}