using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Category>> Create(Category category)
        {
            await _unitOfWork.Categories.Create(category);
            if (await SaveChange())
            {
                return new ServiceResponse<Category> { Success = true, Message = "Add category Success" };
            }
            else
            {
                return new ServiceResponse<Category> { Success = false, Message = "Error when create new category" };
            }
        }

        public async Task<ServiceResponse<Category>> Delete(Category category)
        {
            var feedBackFromDB = await Find(x => x.Id == category.Id);
            if (feedBackFromDB != null)
            {
                _unitOfWork.Categories.Delete(category);
                if (!await SaveChange())
                {
                    return new ServiceResponse<Category> { Success = false, Message = "Error when delete category" };
                }
                return new ServiceResponse<Category> { Success = true, Message = "Delete category Success" };
            }
            else
            {
                return new ServiceResponse<Category> { Success = false, Message = "Not Found Category" };
            }
        }

        public async Task<Category> Find(Expression<Func<Category, bool>> expression = null, List<string> includes = null)
            => await _unitOfWork.Categories.FindByCondition(expression, includes);

        public async Task<ICollection<Category>> FindAll(Expression<Func<Category, bool>> expression = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, List<string> includes = null)
            => await _unitOfWork.Categories.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<Category, bool>> expression = null)
        {
            var isExist = await _unitOfWork.Categories.FindByCondition(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
            => await _unitOfWork.Categories.Save();

        public async Task<ServiceResponse<Category>> Update(Category category)
        {
            var feedBackFromDB = await Find(x => x.Id == category.Id);
            if (feedBackFromDB != null)
            {
                _unitOfWork.Categories.Update(category);
                _unitOfWork.Categories.Delete(category);
                if (!await SaveChange())
                {
                    return new ServiceResponse<Category> { Success = false, Message = "Error when update category" };
                }
                return new ServiceResponse<Category> { Success = true, Message = "Update Category Success" };
            }
            else
            {
                return new ServiceResponse<Category> { Success = false, Message = "Not Found Category" };
            }
        }
    }
}