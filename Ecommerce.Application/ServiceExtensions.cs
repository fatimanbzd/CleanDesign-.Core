using Ecommerce.API.IServices;
using Ecommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
