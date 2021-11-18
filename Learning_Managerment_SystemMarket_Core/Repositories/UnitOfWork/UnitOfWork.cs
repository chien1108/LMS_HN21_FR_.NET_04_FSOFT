using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Data;
using System;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LMSDbContext _context;
        public UnitOfWork(LMSDbContext context)
        {
            _context = context;
        }


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
