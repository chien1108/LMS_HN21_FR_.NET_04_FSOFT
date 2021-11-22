using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.CategoryServices
{
    public interface ICategoryService
    {
        Task<ServiceResponse<Category>> Create(Category category);

        Task<ServiceResponse<Category>> Delete(Category category);
        Task<ServiceResponse<Category>> Update(Category category);
        Task<bool> IsExisted(Expression<Func<Category, bool>> expression = null);
        Task<ICollection<Category>> FindAll(Expression<Func<Category,
                                bool>> expression = null,
                                Func<IQueryable<Category>,
                               IOrderedQueryable<Category>> orderBy = null,
                                List<string> includes = null);
        Task<Category> Find(Expression<Func<Category, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}
