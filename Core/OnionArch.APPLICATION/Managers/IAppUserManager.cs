using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.APPLICATION.DTOs.AppUser;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.APPLICATION.Managers
{
    public interface IAppUserManager:IManager<AppUser,AppUserDTO>
    {
    }
}
