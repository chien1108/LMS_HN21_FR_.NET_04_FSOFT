using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.SubCategoryService
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SubCategory>> Create(SubCategory newSubCategory)
        {
            var subCategoryFromDb = await Find(x => x.Id == newSubCategory.Id);
            if (subCategoryFromDb == null)
            {
                await _unitOfWork.SubCategories.Create(newSubCategory);
                return new ServiceResponse<SubCategory> { Success = true, Message = "Add SubCategory Success" };
            }
            else
            {
                return new ServiceResponse<SubCategory> { Success = false, Message = "SubCategory is Exist" };
            }
        }

        public async Task<ServiceResponse<SubCategory>> Delete(SubCategory subCategory)
        {
            var subCategoryFromDb = await Find(x => x.Id == subCategory.Id);
            if (subCategoryFromDb != null)
            {
                _unitOfWork.SubCategories.Delete(subCategory);
                return new ServiceResponse<SubCategory> { Success = true, Message = "Delete SubCategory Success" };
            }
            else
            {
                return new ServiceResponse<SubCategory> { Success = false, Message = "Not Found SubCategory" };
            }
        }

        public async Task<SubCategory> Find(Expression<Func<SubCategory, bool>> expression = null, 
                                            List<string> includes = null)
            => await _unitOfWork.SubCategories.FindByCondition(expression, includes);

        public async Task<IList<SubCategory>> FindAll(Expression<Func<SubCategory, bool>> expression = null,
                                                      Func<IQueryable<SubCategory>, IOrderedQueryable<SubCategory>> orderBy = null,
                                                      List<string> includes = null)
            => await _unitOfWork.SubCategories.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<SubCategory, bool>> expression = null)
            => await _unitOfWork.SubCategories.IsExists(expression);

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<SubCategory>> Update(SubCategory updateSubCategory)
        {
            var subCategoryFromDb = await Find(x => x.Id == updateSubCategory.Id);
            if (subCategoryFromDb != null)
            {
                _unitOfWork.SubCategories.Update(updateSubCategory);
                return new ServiceResponse<SubCategory> { Success = true, Message = "Update SubCategory Success" };
            }
            else
            {
                return new ServiceResponse<SubCategory> { Success = false, Message = "Not Found SubCategory" };
            }
        }
    }
}