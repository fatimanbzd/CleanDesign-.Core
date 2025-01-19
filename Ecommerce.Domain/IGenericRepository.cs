using System.Linq.Expressions;

namespace Ecommerce.Domain
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync(bool tracked = false);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Remove(int id);
        Task SaveAsync();

    }
}
