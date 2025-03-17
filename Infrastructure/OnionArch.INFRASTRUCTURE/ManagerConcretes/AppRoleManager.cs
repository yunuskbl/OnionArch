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
    public class AppRoleManager: BaseManager<AppRole,AppRoleDTO>,IAppRoleManager
    {
<<<<<<< HEAD

        public AppRoleManager(IAppRoleRepository repository,IMapper mapper) : base(repository,mapper)
        {
          
=======
        IAppRoleRepository _repository;

        public AppRoleManager(IAppRoleRepository repository, IMapper mapper) :base(repository,mapper)
        {
            _repository = repository;
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        }
    }
}
