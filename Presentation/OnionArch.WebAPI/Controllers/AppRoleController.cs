using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.AppRole;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.INFRASTRUCTURE.ManagerConcretes;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppRoleController : IController<AppRole,AppRoleDTO,IAppRoleManager>
        //BaseController<AppRole,AppRoleDTO,IAppRoleManager>
    {
        public AppRoleController(IAppRoleManager manager, IMapper mapper,ILoggerService logger)
        {
                
        }

        public Task<IActionResult> CreateAsync(AppRoleDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateAsync(AppRoleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
