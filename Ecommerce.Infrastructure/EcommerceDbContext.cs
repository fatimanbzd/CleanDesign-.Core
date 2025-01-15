using Ecommerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
   

    }
}
