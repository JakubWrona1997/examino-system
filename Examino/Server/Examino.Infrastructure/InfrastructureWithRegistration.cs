﻿using Examino.Domain;
using Examino.Domain.Contracts;
using Examino.Infrastructure.Middleware;
using Examino.Infrastructure.Repositories;
using Examino.Infrastructure.Services;
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

            // repository services
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IRaportRepository, RaportRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddSingleton<IUserProvider, UserProvider>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IHangFireService, HangFireService>();

            return services;
        }
        public static IHostBuilder AddExaminoInfrastructureHostConfiguration(this IHostBuilder host)
        {         
            host.UseNLog();

            return host;
        }

    }
}
