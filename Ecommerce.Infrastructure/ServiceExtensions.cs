using Ecommerce.Domain.Core.Repositories;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositpries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:EcommerceConnection",
                x => x.MigrationsAssembly("Ecommerce.Infrastructure")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void MigrateDatabase(this IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<EcommerceDbContext>>();

            using (var dbContext = new EcommerceDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
