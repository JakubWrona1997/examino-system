﻿using Examino.Application.Functions.Registration.PatientRegistration;
using Examino.Application.Functions.Registration.PatientRegistration.Command.RegisterPatient;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application
{
   public static class ApplicationWithRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddFluentValidation();

            //Validation services

            services.AddScoped<IValidator<RegisterPatientCommand>, RegisterPatientCommandValidator>();

            return services;
        }
    }
}
