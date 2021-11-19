using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Repositories.AdminSettingRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.SpecialDiscountRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.StudentRepo;
using System;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LMSDbContext _context;
        private IAdminSettingRepository _adminSettingRepository;
        private IInstructorRepository _instructorRepository;
        private ISpecialDiscountRepository _specialDiscountRepository;
        private IStudentRepository _studentRepository;

        public UnitOfWork(LMSDbContext context)
        {
            _context = context;
        }



        public IAdminSettingRepository AdminSettings => _adminSettingRepository ??= new AdminSettingRepository(_context);

        public IInstructorRepository Instructors => _instructorRepository ??= new InstructorRepository(_context);

        public ISpecialDiscountRepository SpecialDiscounts => _specialDiscountRepository ??= new SpecialDiscountRepository(_context);

        public IStudentRepository Students => _studentRepository ??= new StudentRepository(_context);
        //public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);

        //public ITagRepository Tags => _tagRepository ??= new TagRepository(_context);

        //public IPostRepository Posts => _postRepository ??= new PostRepository(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }

        public async Task<bool> Save() => await _context.SaveChangesAsync() > 0;
    }
}
