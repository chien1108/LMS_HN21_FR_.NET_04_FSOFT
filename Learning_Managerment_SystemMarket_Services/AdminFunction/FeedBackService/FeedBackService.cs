using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.FeedBackService
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeedBackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FeedBack>> Create(FeedBack newFeedBack)
        {
            await _unitOfWork.FeedBacks.Create(newFeedBack);
            if (!await SaveChange())
            {
                return new ServiceResponse<FeedBack> { Success = false, Message = "Something wrongs went create new FeedBack" };
            }
            return new ServiceResponse<FeedBack> { Success = true, Message = "Add FeedBack Success" };
        }

        public async Task<ServiceResponse<FeedBack>> Delete(FeedBack feedBack)
        {
            var feedBackFromDB = await Find(x => x.Id == feedBack.Id);
            if (feedBackFromDB != null)
            {
                _unitOfWork.FeedBacks.Delete(feedBack);
                if (!await SaveChange())
                {
                    return new ServiceResponse<FeedBack> { Success = false, Message = "Something wrongs went delete new FeedBack" };
                }
                return new ServiceResponse<FeedBack> { Success = true, Message = "Delete AdminSetting Success" };
            }
            else
            {
                return new ServiceResponse<FeedBack> { Success = false, Message = "Not Found AdminSetting" };
            }
        }

        public async Task<FeedBack> Find(Expression<Func<FeedBack, bool>> expression = null,
                                         List<string> includes = null)
            => await _unitOfWork.FeedBacks.FindByCondition(expression, includes);

        public async Task<IList<FeedBack>> FindAll(Expression<Func<FeedBack, bool>> expression = null,
                                             Func<IQueryable<FeedBack>, IOrderedQueryable<FeedBack>> orderBy = null,
                                             List<string> includes = null)
            => await _unitOfWork.FeedBacks.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<FeedBack, bool>> expression = null)
            => await _unitOfWork.FeedBacks.IsExists(expression);

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<FeedBack>> Update(FeedBack updateFeedBack)
        {
            var feedBackFromDB = await Find(x => x.Id == updateFeedBack.Id);
            if (feedBackFromDB != null)
            {
                _unitOfWork.FeedBacks.Update(updateFeedBack);
                if (!await SaveChange())
                {
                    return new ServiceResponse<FeedBack> { Success = false, Message = "Something wrongs went update new FeedBack" };
                }
                return new ServiceResponse<FeedBack> { Success = true, Message = "Update AdminSetting Success" };
            }
            else
            {
                return new ServiceResponse<FeedBack> { Success = false, Message = "Not Found AdminSetting" };
            }
        }
    }
}