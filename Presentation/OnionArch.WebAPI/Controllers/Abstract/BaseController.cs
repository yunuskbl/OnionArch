using AutoMapper;
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
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                _logger.LogInformationAsync("GetAllAsync Metodu Çalıştı");
                List<TDto> dtos = await _manager.GetAllAsync();

                Console.WriteLine($"GetAllAsync Methodu {dtos?.Count ?? 0} kayıt");

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
                _logger.LogErrorAsync($"GetAllAsync metodu hatası: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Veriler getirilirken bir hata oluştu",
                    error = ex.Message
                });
            }


        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            try
            {
                var dto = await _manager.GetByIdAsync(id);
                if (dto == null)
                {
                    _logger.LogErrorAsync($" GetByIdAsync: ID={id} için veri bulunamadı");
                    return StatusCode(500,new
                    {
                        success = false,
                        message = "Veri bulunamadı"
                    });
                }

                _logger.LogInformationAsync($"GetByIdAsync: ID={id} için veri getirildi");
                return Ok(new
                {
                    success = true,
                    data = dto
                });
            }
            catch (Exception ex)
            {
                _logger.LogErrorAsync($"GetByIdAsync hatası: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Veri getirilirken bir hata oluştu",
                    error = ex.Message
                });
            }

        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync(TDto dto)
        {
            try
            {
                _logger.LogInformationAsync("CreateAsync metodu çalıştı");
                string logMessage = await _manager.CreateAsync(dto);
                return Ok(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch (Exception ex)
            {
                _logger.LogErrorAsync($"CreateAsync hatası: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ekleme işleminde bir hata oluştu",
                    error = ex.Message
                });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(TDto dto)
        {
            try
            {
                _logger.LogInformationAsync("UpdateAsync metodu çalıştı");
                string logMessage = await _manager.UpdateAsync(dto);
                return Ok(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch (Exception ex)
            {
                _logger.LogErrorAsync("UpdateAsync metodu çalıştı fakat bir hata oluştu");
                return StatusCode(500, new { message = "Güncelleme işleminde bir hata oluştu", ex });
            }
        }

        [HttpPut("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var dto = await _manager.GetByIdAsync(id);

                if (dto == null)
                {
                    _logger.LogErrorAsync($"DeleteAsync: ID={id} için veri bulunamadı");
                    return NotFound(new
                    {
                        success = false,
                        message = "Silinecek veri bulunamadı"
                    });
                }

                string logMessage = await _manager.DeleteAsync(dto);
                _logger.LogInformationAsync($"DeleteAsync: ID={id} için soft delete yapıldı");

                return Ok(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch (Exception ex)
            {
                _logger.LogErrorAsync($"DeleteAsync hatası: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Silme işlemi sırasında bir hata oluştu",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            try
            {
                var dto = await _manager.GetByIdAsync(id);

                if (dto == null)
                {
                    _logger.LogErrorAsync($"RemoveAsync: ID={id} için veri bulunamadı");
                    return NotFound(new
                    {
                        success = false,
                        message = "Kalıcı olarak silinecek veri bulunamadı"
                    });
                }

                string logMessage = await _manager.RemoveAsync(dto);
                _logger.LogInformationAsync($"RemoveAsync: ID={id} için hard delete yapıldı");

                return Ok(new
                {
                    success = true,
                    message = logMessage
                });
            }
            catch (Exception ex)
            {
                _logger.LogErrorAsync($"RemoveAsync hatası: {ex.Message}");
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
