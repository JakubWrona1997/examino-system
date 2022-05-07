﻿using Examino.Infrastructure.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure
{
    public static class InfrastructureWithRegistration
    {
        public static IServiceCollection AddExaminoInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ISqlConnectionService, SqlConnectionService>(_ => new SqlConnectionService(configuration.GetConnectionString("DefaultConnection")));
            //error middleware
            services.AddScoped<ErrorHandlingMiddleware>();

            return services;
        }
        public static IHostBuilder AddExaminoInfrastructureHostConfiguration(this IHostBuilder host)
        {         
            host.UseNLog();

            return host;
        }

    }
}
