using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.ClaimService
{
    public interface IClaimService
    {
        Task<ServiceResponse<Claim>> Create(Claim newClaim);

        Task<ServiceResponse<Claim>> Delete(Claim claim);
        Task<ServiceResponse<Claim>> Update(Claim updateClaim);
        Task<bool> IsExisted(Expression<Func<Claim, bool>> expression = null);
        Task<ICollection<Claim>> FindAll(Expression<Func<Claim,
                                bool>> expression = null,
                                Func<IQueryable<Claim>,
                               IOrderedQueryable<Claim>> orderBy = null,
                                List<string> includes = null);
        Task<Claim> Find(Expression<Func<Claim, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}