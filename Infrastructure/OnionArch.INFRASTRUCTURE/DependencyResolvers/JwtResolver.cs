using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.DOMAIN.Concretes;
using OnionArch.INFRASTRUCTURE.Services.JWT;

namespace OnionArch.INFRASTRUCTURE.DependencyResolvers
{
    public static class JwtResolver
    {
        public static void AddJwtService(this IServiceCollection services)
        {
            services.AddScoped<JwtTokenGenerator>();
        }
    }
}
