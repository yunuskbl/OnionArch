using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.PERSISTENCE.ContextClasses;

namespace OnionArch.PERSISTENCE.DependencyResolvers
{
    public static class DbContextServiceInjection
    {
        public static void AddDbContextService(this IServiceCollection services)
        {
                
            ServiceProvider provide = services.BuildServiceProvider();
            IConfiguration configuration = provide.GetService<IConfiguration>();

            services.AddDbContext<MyContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MyConnectionString")).UseLazyLoadingProxies());
        }
    }
}
