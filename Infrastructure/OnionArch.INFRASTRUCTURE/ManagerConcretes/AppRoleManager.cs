using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.AppRole;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class AppRoleManager : BaseManager<AppRole, AppRoleDTO>, IAppRoleManager
    {

        public AppRoleManager(IAppRoleRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
