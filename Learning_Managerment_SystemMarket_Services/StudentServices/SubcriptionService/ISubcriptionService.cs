using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.SubcriptionService
{
    public interface ISubcriptionService
    {
        Task<ICollection<SubScription>> GetAllSubInstructorByStudentId(int studentId);
        Task<ServiceResponse<SubScription>> CreateSubcription(SubScription subScription);
       
    }
}
