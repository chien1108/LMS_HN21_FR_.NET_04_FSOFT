using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.InstructorService
{
    public interface IInstructorService
    {
        Task<ServiceResponse<Instructor>> Create(Instructor newInstructor);

        Task<ServiceResponse<Instructor>> Delete(Instructor instructor);

        Task<ServiceResponse<Instructor>> Update(Instructor updateInstructor);

        Task<bool> IsExisted(Expression<Func<Instructor, bool>> expression = null);

        Task<IList<Instructor>> FindAll(Expression<Func<Instructor, bool>> expression = null,
                                        Func<IQueryable<Instructor>,
                                        IOrderedQueryable<Instructor>> orderBy = null,
                                        List<string> includes = null);

        Task<Instructor> Find(Expression<Func<Instructor, bool>> expression = null, 
                              List<string> includes = null);

        Task<bool> SaveChange();
    }
}