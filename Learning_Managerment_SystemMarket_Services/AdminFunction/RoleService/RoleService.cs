using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.AdminFunction.ClaimService;
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
        private readonly UserManager<User> _userManager;
        private readonly IClaimService _claimService;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<Role> roleManager, UserManager<User> userManager,IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
            _claimService = claimService;
        }

        public async Task<ServiceResponse<Role>> Create(Role newRole, List<Claim> claims)
        {
            var roleFromDb = await Find(x => x.Name == newRole.Name);
            if (roleFromDb == null)
            {
                var result = await _roleManager.CreateAsync(newRole);
                var role = await _roleManager.FindByNameAsync(newRole.Name);
                foreach (var item in claims)
                {
                    item.RoleId = role.Id;
                    var resultAddClaim = await _claimService.Create(item);
                    if (!resultAddClaim.Success)
                    {
                        return new ServiceResponse<Role> { Success = false, Message = "An error while creating Role" };
                    }
                }
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
        {
            var result = await _roleManager.Roles.ToListAsync();
            return result;
        }

        public async Task<bool> IsExisted(string roleName)
            => await _roleManager.RoleExistsAsync(roleName);

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<Role>> Update(Role updateRole, List<Claim> newClaims, List<Claim> removeClaims)
        {
            var roleFromDb = await Find(x => x.Id == updateRole.Id);
            if (roleFromDb != null)
            {
                var result = await _roleManager.UpdateAsync(updateRole);
                var role = await _roleManager.FindByNameAsync(updateRole.Name);
                foreach (var item in newClaims)
                {
                    item.RoleId = role.Id;
                    var resultAddClaim = await _claimService.Create(item);
                    if (!resultAddClaim.Success)
                    {
                        return new ServiceResponse<Role> { Success = false, Message = "An error while update Role" };
                    }
                }
                foreach (var item in removeClaims)
                {
                    var resultRemoveClaims = await _claimService.Delete(item);
                    if (!resultRemoveClaims.Success)
                    {
                        return new ServiceResponse<Role> { Success = false, Message = "An error while update Role" };
                    }
                }
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