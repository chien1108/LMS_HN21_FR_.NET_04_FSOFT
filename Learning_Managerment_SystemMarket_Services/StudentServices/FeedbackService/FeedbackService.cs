using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.FeedbackService
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public FeedbackService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }
        public async Task<ServiceResponse<FeedBack>> Create(FeedBack feedBack)
        {
            try
            {
                await _unitOfWork.FeedBacks.Create(feedBack);
                if (await SaveChange())
                {
                    return new ServiceResponse<FeedBack> { Success = true, Message = "Add feedback Success" };
                }
                else
                {
                    return new ServiceResponse<FeedBack> { Success = false, Message = "Error when create new feedback" };
                }
            }
            catch (Exception)
            {
                return new ServiceResponse<FeedBack> { Success = false, Message = "Create fail" };
            }
        }

        public async Task<bool> SaveChange()
        {
            return await _unitOfWork.Save();
        }
    }
}
