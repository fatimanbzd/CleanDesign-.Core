
using Ecommerce.Domain.Aggrigates;
using Ecommerce.Domain.Core.Repositories;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositpries;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly EcommerceDbContext _dbContext;
        public UserRepository(EcommerceDbContext context) : base(context)
        {
            _dbContext = context;
        }


        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.AsTracking().SingleAsync(u => u.Email == email);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}