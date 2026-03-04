using App.Application.Interfaces;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register infrastructure services here
            // e.g., services.AddScoped<IMyService, MyService>();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("EMSDBConnection"));
            });

            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();

            return services;
        }
    }
}
