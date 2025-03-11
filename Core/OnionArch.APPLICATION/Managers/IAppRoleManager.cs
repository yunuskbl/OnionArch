using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.APPLICATION.DTOs.AppRole;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.APPLICATION.Managers
{
    public interface IAppRoleManager:IManager<AppRole,AppRoleDTO>
    {
        // public Task<bool> UserHasRoleAsync(int userId, string roleName);
    }
}
