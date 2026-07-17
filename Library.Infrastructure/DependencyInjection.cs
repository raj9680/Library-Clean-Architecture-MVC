using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, string configuration)
        {
            services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(configuration));

            return services;
        }
    }
} 
