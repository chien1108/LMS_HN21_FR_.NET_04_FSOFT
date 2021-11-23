using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<Role> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<ServiceResponse<Role>> Create(Role newRole)
        {
            try
            {
                var roleFromDb = await Find(newRole.Name);
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
            catch (Exception ex)
            {
                return new ServiceResponse<Role> { Success = false, Message = ex.Message};
            }
        }

        public async Task<ServiceResponse<Role>> Delete(Role role)
        {
            try
            {
                var roleFromDb = await Find(role.Name);
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
            catch (Exception ex)
            {
                return new ServiceResponse<Role> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Role> Find(string roleName)
            => await _roleManager.FindByNameAsync(roleName);

        public async Task<IList<Role>> FindAll()
            => await _roleManager.Roles.ToListAsync();

        public async Task<bool> IsExisted(string roleName)
            => await _roleManager.RoleExistsAsync(roleName);

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<Role>> Update(Role updateRole)
        {
            try
            {
                var roleFromDb = await Find(updateRole.Name);
                if (roleFromDb == null)
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
                    return new ServiceResponse<Role> { Success = false, Message = "Role is Exist" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Role> { Success = false, Message = ex.Message };
            }

        }
    }
}