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

        [HttpGet("api/get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                await _logger.LogInformationAsync("GetAllAsync Metodu Çağırıldı");
                List<TDto> dtos = await _manager.GetAllAsync();
                await _logger.LogInformationAsync(" Başarıyla Getirildi");
                return Ok(new { message = $"{dtos} Listelendi" });
            }
            catch (Exception ex)
            {
                await _logger.LogErrorAsync("Ürünler getirilirken hata oluştu", ex);
                return StatusCode(500, new { message = "Bir hata oluştu" });
            }


        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int Id)
        {
            try
            {
                await _logger.LogInformationAsync($"GetByIdAsync Metodu Çağırıldı. Id: {Id}");
                IDto dtos = await _manager.GetByIdAsync(Id);
                if (dtos == null)
                {
                    await _logger.LogWarningAsync($"Id = {Id} Numaralı Bir Veri Yok");
                    return NotFound(new {message="Bulunamadı."});
                }
                await _logger.LogInformationAsync(" Başarıyla Getirildi");
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                await _logger.LogErrorAsync("Ürün getirilirken hata oluştu", ex);
                return StatusCode(500, new { message = "Bir hata oluştu" });
            }

        }

        [HttpPost("api/add")]
        public async Task<IActionResult> CreateAsync(TDto dto)
        {
            try
            {
                await _logger.LogInformationAsync($"Yeni ekleme isteği. Data: {System.Text.Json.JsonSerializer.Serialize(dto)}");
                string message = await _manager.CreateAsync(dto);
                await _logger.LogInformationAsync("Ekleme İşlemi Başarıyla Gerçekleşti");
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                await _logger.LogErrorAsync("Ekleme işleminde hata oluştu", ex);
                return StatusCode(500, new { message = "Ekleme işleminde bir hata oluştu" });
            }
        }

        [HttpPut("api/update")]
        public async Task<IActionResult> UpdateAsync(TDto dto)
        {
            try
            {
                await _logger.LogInformationAsync($"Güncelleme isteği. Data: {System.Text.Json.JsonSerializer.Serialize(dto)}");
                string message = await _manager.UpdateAsync(dto);
                await _logger.LogInformationAsync($"Id: {dto.Id} Numaralı Veri Güncellendi");
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                await _logger.LogErrorAsync($"Id: {dto.Id} olan veri güncelleme işleminde hata oluştu", ex);
                return StatusCode(500, new { message = "Güncelleme işleminde bir hata oluştu" });
            }
        }

        [HttpPut("api/delete")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            try
            {
                await _logger.LogInformationAsync($"Silme isteği. Id: {Id}");
                var dto = await _manager.GetByIdAsync(Id);

                if (dto == null)
                {
                    await _logger.LogWarningAsync($"Silinecek veri bulunamadı. Id: {Id}");
                    return NotFound(new { message = "Veri bulunamadı" });
                }

                string message = await _manager.DeleteAsync(dto);
                await _logger.LogInformationAsync($"Id: {Id} olan veri başarıyla silindi");
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                await _logger.LogErrorAsync($"Id: {Id} olan veri silinirken hata oluştu", ex);
                return StatusCode(500, new { message = "Veri silinirken bir hata oluştu" });
            }
        }

        [HttpDelete("api/remove")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            try
            {
                await _logger.LogInformationAsync($"Ürün kalıcı silme isteği. Id: {Id}");
                var dto = await _manager.GetByIdAsync(Id);

                if (dto == null)
                {
                    await _logger.LogWarningAsync($"Kalıcı silinecek ürün bulunamadı. Id: {Id}");
                    return NotFound(new { message = "Ürün bulunamadı" });
                }

                string message = await _manager.RemoveAsync(dto);
                await _logger.LogInformationAsync($"Id: {Id} olan ürün kalıcı olarak silindi");
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                await _logger.LogErrorAsync($"Id: {Id} olan ürün kalıcı silinirken hata oluştu", ex);
                return StatusCode(500, new { message = "Ürün kalıcı silinirken bir hata oluştu" });
            }
        }
    }
}
