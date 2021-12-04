using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.StudentRepo
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<ICollection<SubScription>> GetAllSubInstructorByStudentId(int studentId);

        Task<ICollection<SubScription>> GetSubByInstructorId(int instructorId);

        Task CreateSubcription(SubScription subScription);
        
        Task DeleteSubcription(SubScription subScription);
        Task<bool> IsSubcribleExist(int studentId,int instuctorId);

    }
}