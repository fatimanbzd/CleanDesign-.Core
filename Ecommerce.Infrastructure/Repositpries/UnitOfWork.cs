using Ecommerce.Domain.Core.Models;
using Ecommerce.Domain.Core.Repositories;
using Ecommerce.Infrastructure.Data;

namespace Ecommerce.Infrastructure.Repositpries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;
        private readonly IDictionary<Type, dynamic> _repositories;


        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, dynamic>();
        }

        public IBaseRepository<T> Repository<T>() where T : BaseEntity
        {
            var entityType = typeof(T);

            if (_repositories.ContainsKey(entityType))
            {
                return _repositories[entityType];
            }
            var repositoryType = typeof(BaseRepository<>);

            var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

            if (repository == null)
            {
                throw new NullReferenceException("Repository should not be null");
            }

            _repositories.Add(entityType, repository);

            return (IBaseRepository<T>)repository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollBackChangesAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
