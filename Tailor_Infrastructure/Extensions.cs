﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tailor_Infrastructure.Repositories;
using Tailor_Infrastructure.Repositories.IRepositories;
using Tailor_Infrastructure.Services;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddServiceInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IJWTService, JWTSerivce>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddScoped<ILoggedUserService, LoggedUserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ServerVersion serverVersion = ServerVersion.Create(new Version("8.0.20"), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
            services.AddDbContext<TaiLorContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseMySql(configuration.GetConnectionString("Default"), serverVersion);
            })
            .AddDbContextFactory<TaiLorContext>(lifetime: ServiceLifetime.Scoped);
            return services;
        }
    }
}