using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.AppUserRole;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class AppUserRoleManager:BaseManager<AppUserRole,AppUserRoleDTO>,IAppUserRoleManager
    {
        IAppUserRoleRepository _repository;

        public AppUserRoleManager(IAppUserRoleRepository repository, IMapper mapper): base(repository,mapper)
        {
            _repository = repository;
        }
    }
}
