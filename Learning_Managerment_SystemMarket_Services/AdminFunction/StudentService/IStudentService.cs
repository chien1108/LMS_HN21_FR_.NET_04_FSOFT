using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<Student>> Create(Student newStudent);

        Task<ServiceResponse<Student>> Delete(Student student);

        Task<Student> Find(Expression<Func<Student, bool>> expression = null, 
                           List<string> includes = null);

        Task<IList<Student>> FindAll(Expression<Func<Student, bool>> expression = null, 
                                     Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null,
                                     List<string> includes = null);

        Task<bool> IsExisted(Expression<Func<Student, bool>> expression = null);

        Task<bool> SaveChange();

        Task<ServiceResponse<Student>> Update(Student updateStudent);
    }
}