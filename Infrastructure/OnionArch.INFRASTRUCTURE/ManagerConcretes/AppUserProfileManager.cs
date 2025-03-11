using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.AppUserProfiles;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class AppUserProfileManager : BaseManager<AppUserProfile, AppUserProfileDTO>, IAppUserProfileManager
    {
        IAppUserProfileRepository _repository;
        public AppUserProfileManager(IAppUserProfileRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
