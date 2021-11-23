using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<User>> Create(User newUser)
        {
            try
            {
                var userFromDb = await Find(newUser.UserName);
                if (userFromDb == null)
                {
                    var result = await _userManager.CreateAsync(newUser);
                    if (result.Succeeded)
                    {
                        return new ServiceResponse<User> { Success = true, Message = "Add User Success" };
                    }
                    else
                    {
                        return new ServiceResponse<User> { Success = false, Message = "An error while creating User" };
                    }
                }
                else
                {
                    return new ServiceResponse<User> { Success = false, Message = "User is Exist" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<User> { Success = false, Message = ex.Message };
            }

        }

        public async Task<ServiceResponse<User>> Delete(User user)
        {
            try
            {
                var userFromDb = await Find(user.UserName);
                if (userFromDb != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return new ServiceResponse<User> { Success = true, Message = "Delete User Success" };
                    }
                    else
                    {
                        return new ServiceResponse<User> { Success = false, Message = "An error while deleting User" };
                    }
                }
                else
                {
                    return new ServiceResponse<User> { Success = false, Message = "Not Found User" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<User> { Success = false, Message = ex.Message };
            }

        }

        public async Task<User> Find(string userName)
            => await _userManager.FindByNameAsync(userName);

        public async Task<IList<User>> FindAll()
            => await _userManager.Users.ToListAsync();

        public async Task<bool> IsExisted(string userName)
            => await Find(userName) != null;

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<User>> Update(User updateUser)
        {
            try
            {
                var userFromDb = await Find(updateUser.UserName);
                if (userFromDb == null)
                {
                    var result = await _userManager.UpdateAsync(updateUser);
                    if (result.Succeeded)
                    {
                        return new ServiceResponse<User> { Success = true, Message = "Add User Success" };
                    }
                    else
                    {
                        return new ServiceResponse<User> { Success = false, Message = "An error while updating User" };
                    }
                }
                else
                {
                    return new ServiceResponse<User> { Success = false, Message = "User is Exist" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<User> { Success = false, Message = ex.Message };
            }

        }
    }
}