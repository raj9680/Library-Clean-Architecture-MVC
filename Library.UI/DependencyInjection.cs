using Library.Application;
using Library.Application.Interfaces;
using Library.Infrastructure;
using Library.Infrastructure.Services.TempService;

namespace Library.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDI(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

    //string connectionString =
    //configuration["ConnectionStrings:DefaultConnection"]!;

            services.AddApplicationDI()
                .AddInfrastructureDI(connectionString);
            return services;
        }
    }
}
