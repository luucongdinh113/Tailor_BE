using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using System.Reflection;
using Tailor_Infrastructure;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Tailor_Business
{
    public static class Extensions
    {
        public static IServiceCollection AddServiceBusiness(this IServiceCollection services, IConfiguration configuration) {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddServiceInfrastructure(configuration);
            return services;
        }
    }
}