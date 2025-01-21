using Ecommerce.Domain.Core.Models;
using Ecommerce.Domain.Core.Repositories;
using Ecommerce.Domain.Core.Specifications;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.Repositpries
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly EcommerceDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<T>> GetAllAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<IList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
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

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
        }
    }
}