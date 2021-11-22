using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.InstructorService
{
    public class InstructorService : IInstructorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstructorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Instructor>> Create(Instructor newInstructor)
        {
            var instructorFromDb = await Find(x => x.Id == newInstructor.Id);
            if (instructorFromDb == null)
            {
                await _unitOfWork.Instructors.Create(newInstructor);
                return new ServiceResponse<Instructor> { Success = true, Message = "Add Instructor Success" };
            }
            else
            {
                return new ServiceResponse<Instructor> { Success = false, Message = "Instructor is Exist" };
            }
        }

        public async Task<ServiceResponse<Instructor>> Delete(Instructor instructor)
        {
            var instructorFromDb = await Find(x => x.Id == instructor.Id);
            if (instructorFromDb != null)
            {
                _unitOfWork.Instructors.Delete(instructor);
                return new ServiceResponse<Instructor> { Success = true, Message = "Delete Instructor Success" };
            }
            else
            {
                return new ServiceResponse<Instructor> { Success = false, Message = "Not Found Instructor" };
            }
        }

        public async Task<Instructor> Find(Expression<Func<Instructor, bool>> expression = null,
                                           List<string> includes = null)
            => await _unitOfWork.Instructors.FindByCondition(expression, includes);

        public async Task<IList<Instructor>> FindAll(Expression<Func<Instructor, bool>> expression = null,
                                               Func<IQueryable<Instructor>, IOrderedQueryable<Instructor>> orderBy = null,
                                               List<string> includes = null)
            => await _unitOfWork.Instructors.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<Instructor, bool>> expression = null)
            => await _unitOfWork.Instructors.IsExists(expression);

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<Instructor>> Update(Instructor updateInstructor)
        {
            var instructorFromDb = await Find(x => x.Id == updateInstructor.Id);
            if (instructorFromDb != null)
            {
                _unitOfWork.Instructors.Update(updateInstructor);
                return new ServiceResponse<Instructor> { Success = true, Message = "Update Instructor Success" };
            }
            else
            {
                return new ServiceResponse<Instructor> { Success = false, Message = "Not Found Instructor" };
            }
        }
    }
}