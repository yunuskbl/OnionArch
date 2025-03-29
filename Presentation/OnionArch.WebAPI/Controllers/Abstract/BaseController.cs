using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.WebAPI.Controllers.Abstract
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TDto, TManager> : ControllerBase
        where TEntity : class, IEntity
        where TDto : class, IDto
        where TManager : class, IManager<TEntity, TDto>
    {
        protected TManager _manager;
        protected IMapper _mapper;
        protected ILoggerService _logger;

        public BaseController(TManager manager, IMapper mapper, ILoggerService logger)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("get-all")]
        [Authorize(Roles ="Admin,Supplier,Moderator,Editor,Guest")]
        public async Task<IActionResult> GetAllAsync()
        {

            try
            {
                List<TDto> dtos = await _manager.GetAllAsync();


                if (dtos==null || !dtos.Any())
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Veri bulunamadı"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = dtos,
                    total=dtos.Count,
                    message= "Listeleme Başarılı"
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Veriler getirilirken bir hata oluştu",
                    error = ex.Message
                });
            }


        }

        [HttpGet("get-by-id")]
        [Authorize(Roles ="Admin,Supplier,Moderator,Editor")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            try
            {
                var dto = await _manager.GetByIdAsync(id);
                if (dto == null)
                {
                    return StatusCode(500,new
                    {
                        success = false,
                        message = "Veri bulunamadı"
                    });
                }

                return Ok(new
                {
                    success = true,
                    data = dto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Veri getirilirken bir hata oluştu",
                    error = ex.Message
                });
            }

        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin,GeneralManager,SuperAdmin")]
        public async Task<IActionResult> CreateAsync(TDto dto)
        {
            try
            {
                string logMessage = await _manager.CreateAsync(dto);
                return Ok(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch (Exception ex)
            {
                return BadRequest( new
                {
                    success = false,
                    message = "Ekleme işleminde bir hata oluştu",
                    error = ex
                });
            }
        }

        [HttpPut("update")]
        [Authorize(Roles ="Admin,Supplier,Moderator,Editor")]
        public async Task<IActionResult> UpdateAsync(TDto dto)
        {
            try
            {
                string logMessage = await _manager.UpdateAsync(dto);
                return Ok(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Güncelleme işleminde bir hata oluştu", ex });
            }
        }

        [HttpPut("delete")]
        [Authorize(Roles = "Admin,GeneralManager,SuperAdmin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var dto = await _manager.GetByIdAsync(id);

                if (dto == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Silinecek veri bulunamadı"
                    });
                }

                string logMessage = await _manager.DeleteAsync(dto);

                return Ok(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Silme işlemi sırasında bir hata oluştu",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("remove")]
        [Authorize(Roles ="Admin,Moderator")]

        public async Task<IActionResult> RemoveAsync(int id)
        {
            
            try
            {
                var dto = await _manager.GetByIdAsync(id);

                if (dto == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Kalıcı olarak silinecek veri bulunamadı"
                    });
                }

                string logMessage = await _manager.RemoveAsync(dto);

                return Ok(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Kalıcı silme işlemi sırasında bir hata oluştu",
                    error = ex.Message
                });
            }
        }
    }
}
