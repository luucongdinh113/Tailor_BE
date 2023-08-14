using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tailor_Infrastructure.Services;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddServiceInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IJWTService, JWTSerivce>();
            services.AddDbContext<TaiLorContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
            })
            .AddDbContextFactory<TaiLorContext>(lifetime: ServiceLifetime.Scoped);
            return services;
        }
    }
}