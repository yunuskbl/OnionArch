using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.APPLICATION.FluentValidation;

namespace OnionArch.APPLICATION.DependencyResolvers
{
    public static class FluentValidationServiceInjection
    {
        public static void AddFluentValidationService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AppUserValidator>();
            services.AddValidatorsFromAssemblyContaining<AppRoleValidator>();
        }
    }
}
