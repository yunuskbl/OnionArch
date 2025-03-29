using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.AppRole;
using OnionArch.APPLICATION.DTOs.AppUser;
using OnionArch.APPLICATION.FluentValidation;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.INFRASTRUCTURE.CrossCuttingConcerns.Logging;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : BaseController<AppUser, AppUserDTO, IAppUserManager>
    {
        private readonly IValidator<AppUserValidator> _validator;
        public AppUserController(IAppUserManager manager, IMapper mapper, ILoggerService logger, IValidator<AppUserValidator> validator) : base(manager, mapper, logger)
        {
            _validator = validator;
        }
    }
}
