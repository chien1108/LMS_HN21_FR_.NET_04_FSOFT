using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.FeedBackService
{
    public interface IFeedBackService
    {
        //Task<ServiceResponse<List<FeedBack>>> GetAllFeedBack();
        //Task<ServiceResponse<FeedBack>> GetFeedBackById(int id);
        //Task<ServiceResponse<List<FeedBack>>> AddFeedBack(FeedBack newFeedBack);
        //Task<ServiceResponse<FeedBack>> UpdateFeedBack(FeedBack updateFeedBack);
        //Task<ServiceResponse<List<FeedBack>>> DeleteFeedBack(int id);
        Task<ServiceResponse<FeedBack>> Create(FeedBack newFeedBack);

        Task<ServiceResponse<FeedBack>> Delete(FeedBack feedBack);
        Task<ServiceResponse<FeedBack>> Update(FeedBack updateFeedBack);
        Task<bool> IsExisted(Expression<Func<FeedBack, bool>> expression = null);
        Task<IList<FeedBack>> FindAll(Expression<Func<FeedBack,
                                bool>> expression = null,
                                Func<IQueryable<FeedBack>,
                               IOrderedQueryable<FeedBack>> orderBy = null,
                                List<string> includes = null);
        Task<FeedBack> Find(Expression<Func<FeedBack, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}