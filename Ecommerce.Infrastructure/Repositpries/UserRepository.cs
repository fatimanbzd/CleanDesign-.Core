
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly EcommerceDbContext _dbContext;
        public UserRepository(EcommerceDbContext context) : base(context)
        {
            _dbContext = context;
        }


        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}