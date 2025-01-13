
using Ecommerce.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class EcommerceDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.UserType).IsRequired();
            });
        }
    }
}
