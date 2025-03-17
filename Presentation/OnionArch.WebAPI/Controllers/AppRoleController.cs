using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.AppRole;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AppRoleController : BaseController<AppRole,AppRoleDTO,IAppRoleManager>
    {
        public AppRoleController(IAppRoleManager manager, IMapper mapper,ILoggerService logger) : base(manager, mapper,logger)
        {
                
        }
    }
}
