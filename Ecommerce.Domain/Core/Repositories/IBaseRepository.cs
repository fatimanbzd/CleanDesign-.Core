using Ecommerce.Domain.Core.Models;
using Ecommerce.Domain.Core.Specifications;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Core.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync(bool tracked = false);
        Task<IList<T>> ListAsync(ISpecification<T> spec);
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<T?> FirstOrDefaultAsync(ISpecification<T> spec);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Remove(int id);
        Task<int> CountAsync(ISpecification<T> spec);
        Task SaveAsync();

    }
}
