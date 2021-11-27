using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
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
    }
}
