using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.FeedbackService
{
    public interface IFeedbackService
    {
        Task<ServiceResponse<FeedBack>> Create(FeedBack feedBack);
    }
}
