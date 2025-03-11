using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.APPLICATION.Managers;
using OnionArch.INFRASTRUCTURE.ManagerConcretes;

namespace OnionArch.INFRASTRUCTURE.DependencyResolvers
{
    public static class ManagerResolver
    {
        public static void AddManagerService(this IServiceCollection services)
        {
            services.AddScoped<IAppRoleManager,AppRoleManager>();
            services.AddScoped<IAppUserManager,AppUserManager>();
            services.AddScoped<IAppUserProfileManager,AppUserProfileManager>();
            services.AddScoped<IAppUserRoleManager,AppUserRoleManager>();
            services.AddScoped<ICategoryManager,CategoryManager>();
            services.AddScoped<IOrderManager,OrderManager>();
            services.AddScoped<IOrderDetailManager,OrderDetailManager>();
            services.AddScoped<IProductManager,ProductManager>();
        }
    }
}
