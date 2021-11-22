using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.FAQService
{
    public interface IFAQService
    {
        Task<ServiceResponse<FAQ>> Create(FAQ newFAQ);

        Task<ServiceResponse<FAQ>> Delete(FAQ FAQ);

        Task<ServiceResponse<FAQ>> Update(FAQ updateFAQ);

        Task<bool> IsExisted(Expression<Func<FAQ, bool>> expression = null);

        Task<IList<FAQ>> FindAll(Expression<Func<FAQ, bool>> expression = null,
                                 Func<IQueryable<FAQ>,
                                 IOrderedQueryable<FAQ>> orderBy = null,
                                 List<string> includes = null);

        Task<FAQ> Find(Expression<Func<FAQ, bool>> expression = null, 
                       List<string> includes = null);

        Task<bool> SaveChange();
    }
}