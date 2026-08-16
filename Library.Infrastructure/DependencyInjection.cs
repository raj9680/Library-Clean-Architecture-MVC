using Library.Application.Interfaces;
using Library.Infrastructure.Data;
using Library.Infrastructure.Services.TempService;
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

            // Temp
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }
    }
} 
