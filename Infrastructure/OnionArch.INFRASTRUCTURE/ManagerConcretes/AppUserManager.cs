using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnionArch.APPLICATION.DTOs.AppUser;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;
using OnionArch.INFRASTRUCTURE.CrossCuttingConcerns.Logging;
using Serilog;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class AppUserManager : BaseManager<AppUser, AppUserDTO>, IAppUserManager
    {
        private readonly IAppUserRepository _userRepository;
        public AppUserManager(IAppUserRepository repository, IMapper mapper, IAppUserRoleRepository userRoleRepository, IAppUserRepository userRepository) : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public AppUser Authenticate(string username, string password)
        {
            var user = _userRepository.GetAllAsync().Result.FirstOrDefault(u => u.UserName == username);
            if (user == null || !VerifyPassword(user.Password, password)) return null;

            return user;
        }

        public IEnumerable<string> GetUserRoles(int userId)
        {
            var user= _userRepository.Where(p => p.Id == userId).Select(x => x.AppUserRoles);
            var roles = user.SelectMany(p => p.Select(x => x.AppRole.RoleName)).ToList();
            return roles;
        }

        public bool VerifyPassword(string storedPassword, string enteredPassword)
        {
            return storedPassword == enteredPassword;
        }

    }
}
