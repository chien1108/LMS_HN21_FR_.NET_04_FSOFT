using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.LanguageService
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Language>> Create(Language newLanguage)
        {
            await _unitOfWork.Languages.Create(newLanguage);
            if (!await SaveChange())
            {
                return new ServiceResponse<Language> { Success = false, Message = "Something wrongs went create new Language" };
            }
            return new ServiceResponse<Language> { Success = true, Message = "Add Language Success" };
        }

        public async Task<ServiceResponse<Language>> Delete(Language language)
        {
            var languageFromDB = await Find(x => x.Id == language.Id);
            if (languageFromDB != null)
            {
                _unitOfWork.Languages.Delete(language);
                if (!await SaveChange())
                {
                    return new ServiceResponse<Language> { Success = false, Message = "Something wrongs went delete new Language" };
                }
                return new ServiceResponse<Language> { Success = true, Message = "Delete Language Success" };
            }
            else
            {
                return new ServiceResponse<Language> { Success = false, Message = "Not Found Language" };
            }
        }

        public async Task<Language> Find(Expression<Func<Language, bool>> expression = null, List<string> includes = null)
         => await _unitOfWork.Languages.FindByCondition(expression, includes);

        public async Task<IList<Language>> FindAll(Expression<Func<Language, bool>> expression = null, 
                                                   Func<IQueryable<Language>, IOrderedQueryable<Language>> orderBy = null, 
                                                   List<string> includes = null)
        => await _unitOfWork.Languages.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<Language, bool>> expression = null)
        => await _unitOfWork.Languages.IsExists(expression);

        public async Task<bool> SaveChange()
        => await _unitOfWork.Save();

        public async Task<ServiceResponse<Language>> Update(Language updateLanguage)
        {
            var languageFromDb = await Find(x => x.Id == updateLanguage.Id);
            if (languageFromDb != null)
            {
                _unitOfWork.Languages.Update(updateLanguage);
                if (!await SaveChange())
                {
                    return new ServiceResponse<Language> { Success = false, Message = "Something wrongs went update new Instructor" };
                }
                return new ServiceResponse<Language> { Success = true, Message = "Update Instructor Success" };
            }
            else
            {
                return new ServiceResponse<Language> { Success = false, Message = "Not Found Instructor" };
            }
        }
    }
}
