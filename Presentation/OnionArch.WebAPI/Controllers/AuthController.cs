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
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAppUserManager userManager, JwtTokenGenerator jwtTokenGenerator, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = _userManager.Authenticate(dto.UserName, dto.Password);
            _logger.LogInformation("Kullanıcı {UserName} giriş yapmaya çalışıyor.", dto.UserName);

            if (user == null)
            {
                return Unauthorized("Yetkisiz Kullanıcı Girişi.");
            }
            else
            {
                var token = await _jwtTokenGenerator.GenerateToken(user);
                _logger.LogInformation("Kullanıcı {UserName} başarılı bir şekilde giriş yaptı.", dto.UserName);
                return Ok(new { Token = token });
            }
        }
        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }
    }
}
