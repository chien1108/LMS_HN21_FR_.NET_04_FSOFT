using Learning_Managerment_SystemMarket_Core.Repositories.AdminSettingRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.SpecialDiscountRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.StudentRepo;
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
