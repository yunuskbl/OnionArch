using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.APPLICATION.Logging;
using OnionArch.INFRASTRUCTURE.CrossCuttingConcerns.Logging;

namespace OnionArch.INFRASTRUCTURE.DependencyResolvers
{
    public static class LoggerResolver
    {
        public static void AddLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILoggerService, SeriLoggerService>();
        }
    }
}
