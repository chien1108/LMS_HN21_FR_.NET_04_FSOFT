using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.SubcriptionService
{
    public class SubcriptionService : ISubcriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public SubcriptionService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }

        public async Task<ICollection<SubScription>> GetAllSubInstructorByStudentId(int studentId)
        {
            var listSubInstructor = await _unitOfWork.Students.GetAllSubInstructorByStudentId(studentId);
            return listSubInstructor;
        }
        public async Task<ServiceResponse<SubScription>> CreateSubcription(SubScription subScription)
        {
            try
            {
                await _unitOfWork.Students.CreateSubcription(subScription);
                if (await SaveChanges())
                {
                    return new ServiceResponse<SubScription> { Success = true, Message = "Add SubScription Success" };
                }
                else
                {
                    return new ServiceResponse<SubScription> { Success = false, Message = "Error when create new SubScription" };
                }
            }
            catch (Exception)
            {
                return new ServiceResponse<SubScription> { Success = false, Message = "Create fail" };
            }
        }
        public async Task<bool> SaveChanges()
        {
            return await _unitOfWork.Save();
        }
    }
}

