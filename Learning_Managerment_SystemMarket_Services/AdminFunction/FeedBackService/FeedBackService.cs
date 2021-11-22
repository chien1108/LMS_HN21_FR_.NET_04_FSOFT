﻿using AutoMapper;
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
            var feedBackFromDb = await Find(x => x.Id == newFeedBack.Id);
            if (feedBackFromDb == null)
            {
                await _unitOfWork.FeedBacks.Create(newFeedBack);
                return new ServiceResponse<FeedBack> { Success = true, Message = "Add FeedBack Success" };
            }
            else
            {
                return new ServiceResponse<FeedBack> { Success = false, Message = "FeedBack is Exist" };
            }
        }

        public async Task<ServiceResponse<FeedBack>> Delete(FeedBack feedBack)
        {
            var feedBackFromDB = await Find (x => x.Id == feedBack.Id);
            if (feedBackFromDB != null)
            {
                _unitOfWork.FeedBacks.Delete(feedBack);
                return new ServiceResponse<FeedBack> { Success = true, Message = "Add AdminSetting Success" };
            }
            else
            {
                return new ServiceResponse<FeedBack> { Success = false, Message = "Not Found AdminSetting" };
            }
        }

        public async Task<FeedBack> Find(Expression<Func<FeedBack, bool>> expression = null, List<string> includes = null)
        => await _unitOfWork.FeedBacks.FindByCondition(expression, includes);

        public Task<IList<FeedBack>> FindAll(Expression<Func<FeedBack, bool>> expression = null, Func<IQueryable<FeedBack>, IOrderedQueryable<FeedBack>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<FeedBack, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<FeedBack>> Update(FeedBack updateFeedBack)
        {
            var feedBackFromDB = await Find(x => x.Id == updateFeedBack.Id);
            if (feedBackFromDB != null)
            {
                _unitOfWork.FeedBacks.Update(updateFeedBack);
                return new ServiceResponse<FeedBack> { Success = true, Message = "Add AdminSetting Success" };
            }
            else
            {
                return new ServiceResponse<FeedBack> { Success = false, Message = "Not Found AdminSetting" };
            }
        }
    }
}
