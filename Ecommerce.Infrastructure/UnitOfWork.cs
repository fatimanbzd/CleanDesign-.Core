using Ecommerce.Domain.Common;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.Repositories;

namespace Ecommerce.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;
        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }
        public IUserRepository Users { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
