using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.AppUserRole;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.INFRASTRUCTURE.CrossCuttingConcerns.Logging;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserRoleManager : BaseController<AppUserRole,AppUserRoleDTO,IAppUserRoleManager>
    {
        public AppUserRoleManager(IAppUserRoleManager manager, IMapper mapper, ILoggerService logger) : base(manager, mapper,logger)
        {
                
        }
    }
}
