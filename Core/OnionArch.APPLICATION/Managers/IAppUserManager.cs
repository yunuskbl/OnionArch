using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.APPLICATION.DTOs.AppUser;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.APPLICATION.Managers
{
    public interface IAppUserManager : IManager<AppUser, AppUserDTO>
    {
        IEnumerable<string> GetUserRoles(int userId);
        AppUser Authenticate(string username, string password);
        bool VerifyPassword(string storedPassword, string enteredPassword);
    }
}
