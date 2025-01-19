using Ecommerce.Domain;
using Ecommerce.Domain.Aggrigates;
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;

        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        //public GenericRepository<User> UserRepository => new GenericRepository<User>(_con);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Dispose()
        {
           await _context.DisposeAsync();
        }
    }
}
