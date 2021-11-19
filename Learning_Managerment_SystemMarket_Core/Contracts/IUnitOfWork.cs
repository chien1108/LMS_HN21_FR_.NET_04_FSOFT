using Learning_Managerment_SystemMarket_Core.Repositories.AdminSettingRepository;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepository;
using Learning_Managerment_SystemMarket_Core.Repositories.SpecialDiscountRepository;
using Learning_Managerment_SystemMarket_Core.Repositories.StudentRepository;
using System;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        //ICategoryRepository Categories { get; }
        //ITagRepository Tags { get; }
        //IPostRepository Posts { get; }

        IAdminSettingRepository AdminSettings { get; }
        IInstructorRepository Instructors { get; }
        ISpecialDiscountRepository SpecialDiscounts { get; }
        IStudentRepository Students { get; }
        Task<bool> Save();
    }
}
