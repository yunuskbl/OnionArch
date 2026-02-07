using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs;
using OnionArch.APPLICATION.Managers;
using OnionArch.INFRASTRUCTURE.Services.JWT;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IAppUserManager _userManager;

        public AuthController(IAppUserManager userManager, JwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _userManager.Authenticate(dto.UserName, dto.Password);
            if (user == null) return Unauthorized("Yetkisiz Kullanıcı Girişi.");
            
            var token = _jwtTokenGenerator.GenerateToken(user);

            return Ok(new {Token=token});
        }
        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }   
    }
}
