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
            return services;
        }
    }
}