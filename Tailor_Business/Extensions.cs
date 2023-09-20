﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tailor_Infrastructure;

namespace Tailor_Business
{
    public static class Extensions
    {
        public static IServiceCollection AddServiceBusiness(this IServiceCollection services, IConfiguration configuration) {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddServiceInfrastructure(configuration);
            return services;
        }
    }
}