using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EcommerceDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task Remove(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                await SaveAsync();
            }

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}