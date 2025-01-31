using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.APPLICATION.Mapping;

namespace OnionArch.APPLICATION.DependencyResolvers
{
    public static class ApplicationMapperServiceInjection
    {
        public static void AddApplicationMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));
        }
    }
}
