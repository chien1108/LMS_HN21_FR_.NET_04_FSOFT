using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.LanguageService
{
    public interface ILanguageService
    {
        Task<ServiceResponse<Language>> Create(Language newLanguage);

        Task<ServiceResponse<Language>> Delete(Language language);

        Task<ServiceResponse<Language>> Update(Language updateLanguage);

        Task<bool> IsExisted(Expression<Func<Language, bool>> expression = null);

        Task<IList<Language>> FindAll(Expression<Func<Language, bool>> expression = null,
                                        Func<IQueryable<Language>,
                                        IOrderedQueryable<Language>> orderBy = null,
                                        List<string> includes = null);

        Task<Language> Find(Expression<Func<Language, bool>> expression = null,
                              List<string> includes = null);

        Task<bool> SaveChange();
    }
}