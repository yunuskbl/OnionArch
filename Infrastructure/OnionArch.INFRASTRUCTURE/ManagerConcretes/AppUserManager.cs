using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.AppUser;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class AppUserManager : BaseManager<AppUser, AppUserDTO>,IAppUserManagers
    {
        IAppUserRepository _repository;
        public AppUserManager(IAppUserRepository repository,IMapper mapper):base(repository,mapper)
        {
                _repository = repository;
        }
    }
}
