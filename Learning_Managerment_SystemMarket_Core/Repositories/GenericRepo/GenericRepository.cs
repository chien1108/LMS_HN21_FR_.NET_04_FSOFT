using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LMSDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(LMSDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task Create(T entity) 
            => await _db.AddAsync(entity);

        public void Delete(T entity) 
            => _db.Remove(entity);

        public async Task<T> FindByCondition(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var table in includes)
                {
                    query = query.Include(table);
                }
            }

            return await query.FirstOrDefaultAsync(expression);

        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            )
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var table in includes)
                {
                    query = query.Include(table);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> IsExists(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = _db;
            return await query.AnyAsync(expression);
        }

        public void Update(T entity) 
            => _db.Update(entity);

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
