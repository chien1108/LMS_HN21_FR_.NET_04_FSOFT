using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.FAQService
{
    public class FAQService : IFAQService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FAQService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FAQ>> Create(FAQ newFAQ)
        {
            var FAQFromDb = await Find(x => x.Id == newFAQ.Id);
            if (FAQFromDb == null)
            {
                await _unitOfWork.FAQs.Create(newFAQ);
                return new ServiceResponse<FAQ> { Success = true, Message = "Add FAQ Success" };
            }
            else
            {
                return new ServiceResponse<FAQ> { Success = false, Message = "FAQ is Exist" };
            }
        }

        public async Task<ServiceResponse<FAQ>> Delete(FAQ FAQ)
        {
            var FAQFromDb = await Find(x => x.Id == FAQ.Id);
            if (FAQFromDb != null)
            {
                _unitOfWork.FAQs.Delete(FAQ);
                return new ServiceResponse<FAQ> { Success = true, Message = "Delete FAQ Success" };
            }
            else
            {
                return new ServiceResponse<FAQ> { Success = false, Message = "Not Found FAQ" };
            }
        }

        public async Task<FAQ> Find(Expression<Func<FAQ, bool>> expression = null,
                                    List<string> includes = null)
            => await _unitOfWork.FAQs.FindByCondition(expression, includes);

        public async Task<IList<FAQ>> FindAll(Expression<Func<FAQ, bool>> expression = null,
                                              Func<IQueryable<FAQ>, IOrderedQueryable<FAQ>> orderBy = null,
                                              List<string> includes = null)
            => await _unitOfWork.FAQs.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<FAQ, bool>> expression = null)
            => await _unitOfWork.FAQs.IsExists(expression);

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<FAQ>> Update(FAQ updateFAQ)
        {
            var FAQFromDb = await Find(x => x.Id == updateFAQ.Id);
            if (FAQFromDb != null)
            {
                _unitOfWork.FAQs.Update(updateFAQ);
                return new ServiceResponse<FAQ> { Success = true, Message = "Update FAQ Success" };
            }
            else
            {
                return new ServiceResponse<FAQ> { Success = false, Message = "Not Found FAQ" };
            }
        }
    }
}