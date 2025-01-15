using Ecommerce.Core;
using Ecommerce.Core.Repositories;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly EcommerceDbContext _dbContext;
        public UserRepository(EcommerceDbContext context) : base(context)
        {
            _dbContext = context;
        }

    }
}