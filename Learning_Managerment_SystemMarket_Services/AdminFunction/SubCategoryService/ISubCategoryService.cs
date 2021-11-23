using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.SubCategoryService
{
    public interface ISubCategoryService
    {
        Task<ServiceResponse<SubCategory>> Create(SubCategory newSubCategory);

        Task<ServiceResponse<SubCategory>> Delete(SubCategory subCategory);

        Task<ServiceResponse<SubCategory>> Update(SubCategory updateSubCategory);

        Task<bool> IsExisted(Expression<Func<SubCategory, bool>> expression = null);

        Task<IList<SubCategory>> FindAll(Expression<Func<SubCategory, bool>> expression = null,
                                        Func<IQueryable<SubCategory>,
                                        IOrderedQueryable<SubCategory>> orderBy = null,
                                        List<string> includes = null);

        Task<SubCategory> Find(Expression<Func<SubCategory, bool>> expression = null,
                              List<string> includes = null);

        Task<bool> SaveChange();
    }
}