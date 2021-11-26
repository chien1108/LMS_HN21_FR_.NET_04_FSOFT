using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.ClaimService
{
    public class ClaimService : IClaimService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClaimService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Claim>> Create(Claim newClaim)
        {
            try
            {
                await _unitOfWork.Claims.Create(newClaim);
                if (await SaveChange())
                {
                    return new ServiceResponse<Claim> { Success = true, Message = "Add claim Success" };
                }
                else
                {
                    return new ServiceResponse<Claim> { Success = false, Message = "Error when create new Claim" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Claim> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<Claim>> Delete(int id)
        {
            try
            {
                var claimFromDB = await FindAll(x => x.Id == id);
                if (claimFromDB != null)
                {
                    foreach (var item in claimFromDB)
                    {
                        _unitOfWork.Claims.Delete(item);
                        if (!await SaveChange())
                        {
                            return new ServiceResponse<Claim> { Success = false, Message = "Error when delete claim" };
                        }
                    }
                    return new ServiceResponse<Claim> { Success = true, Message = "Delete claim Success" };
                }
                else
                {
                    return new ServiceResponse<Claim> { Success = false, Message = "Not Found claim" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Claim> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Claim> Find(Expression<Func<Claim, bool>> expression = null, List<string> includes = null)
        => await _unitOfWork.Claims.FindByCondition(expression, includes);

        public async Task<ICollection<Claim>> FindAll(Expression<Func<Claim, bool>> expression = null, Func<IQueryable<Claim>, IOrderedQueryable<Claim>> orderBy = null, List<string> includes = null)
        => await _unitOfWork.Claims.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<Claim, bool>> expression = null)
        {
            return await _unitOfWork.Claims.FindByCondition(expression) == null;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.Claims.Save();

        public async Task<ServiceResponse<Claim>> Update(Claim updateClaim)
        {
            try
            {
                var claimFromDB = await Find(x => x.Id == updateClaim.Id);
                if (claimFromDB != null)
                {
                    _unitOfWork.Claims.Update(updateClaim);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<Claim> { Success = false, Message = "Error when update claim" };
                    }
                    return new ServiceResponse<Claim> { Success = true, Message = "Update Claim Success" };
                }
                else
                {
                    return new ServiceResponse<Claim> { Success = false, Message = "Not Found Claim" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Claim> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ICollection<Claim>> GetAllClaimInUser(int idRole)
            => await FindAll(x => x.RoleId == idRole);

        public async Task<ServiceResponse<Claim>> DeleteArrange(IList<Claim> claims)
        {
            try
            {
                foreach (var item in claims)
                {
                    if (item != null)
                    {
                        var claimFromDB = await FindAll(x => x.Id == item.Id);
                        if (claimFromDB != null)
                        {
                            _unitOfWork.Claims.Delete(item);
                        }
                        else
                        {
                            return new ServiceResponse<Claim> { Success = false, Message = "Not Found claim" };
                        }
                    }
                }
                if (!await SaveChange())
                {
                    return new ServiceResponse<Claim> { Success = false, Message = "Error when delete claim" };
                }
                return new ServiceResponse<Claim> { Success = true, Message = "Delete claim Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Claim> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<Claim>> Delete(Claim claim)
        {
            try
            {
                var claimFromDB = await FindAll(x => x.Id == claim.Id);
                if (claimFromDB != null)
                {
                    foreach (var item in claimFromDB)
                    {
                        _unitOfWork.Claims.Delete(item);
                        if (!await SaveChange())
                        {
                            return new ServiceResponse<Claim> { Success = false, Message = "Error when delete claim" };
                        }
                    }
                    return new ServiceResponse<Claim> { Success = true, Message = "Delete claim Success" };
                }
                else
                {
                    return new ServiceResponse<Claim> { Success = false, Message = "Not Found claim" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Claim> { Success = false, Message = ex.Message };
            }
        }
    }
}