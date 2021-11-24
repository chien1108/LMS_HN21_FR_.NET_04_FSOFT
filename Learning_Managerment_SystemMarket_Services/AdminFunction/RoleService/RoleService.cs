using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.RoleViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<RoleDetailsVm>> GetRoleClaim()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<RoleDetailsVm> roleDetails = new List<RoleDetailsVm>();
            foreach (var item in roles)
            {
                RoleDetailsVm role = new RoleDetailsVm();
                role.Role = item;
                role.Claim = await _roleManager.GetClaimsAsync(item) as IList<Claim>;
                roleDetails.Add(role);
            }
            return roleDetails;
        }

        public async Task<ServiceResponse<Role>> Create(Role newRole)
        {
            var roleFromDb = await Find(x => x.Name == newRole.Name);
            if (roleFromDb == null)
            {
                var result = await _roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    return new ServiceResponse<Role> { Success = true, Message = "Add Role Success" };
                }
                else
                {
                    return new ServiceResponse<Role> { Success = false, Message = "An error while creating Role" };
                }
            }
            else
            {
                return new ServiceResponse<Role> { Success = false, Message = "Role is Exist" };
            }
        }

        public async Task<ServiceResponse<Role>> Delete(Role role)
        {
            var roleFromDb = await Find(x => x.Name == role.Name);
            if (roleFromDb != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return new ServiceResponse<Role> { Success = true, Message = "Delete Role Success" };
                }
                else
                {
                    return new ServiceResponse<Role> { Success = false, Message = "An error while deleting Role" };
                }
            }
            else
            {
                return new ServiceResponse<Role> { Success = false, Message = "Not Found Role" };
            }
        }

        public async Task<Role> Find(Expression<Func<Role, bool>> expression)
            => await _roleManager.Roles.FirstOrDefaultAsync(expression);

        public async Task<IList<Role>> FindAll()
            => await _roleManager.Roles.ToListAsync();

        public async Task<bool> IsExisted(string roleName)
            => await _roleManager.RoleExistsAsync(roleName);

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<Role>> Update(Role updateRole)
        {
            var roleFromDb = await Find(x => x.Name == updateRole.Name);
            if (roleFromDb != null)
            {
                var result = await _roleManager.UpdateAsync(updateRole);
                if (result.Succeeded)
                {
                    return new ServiceResponse<Role> { Success = true, Message = "Add Role Success" };
                }
                else
                {
                    return new ServiceResponse<Role> { Success = false, Message = "An error while updating Role" };
                }
            }
            else
            {
                return new ServiceResponse<Role> { Success = false, Message = "Not Found Role" };
            }
        }
    }
}