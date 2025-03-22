using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.Categories;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.INFRASTRUCTURE.CrossCuttingConcerns.Logging;
using OnionArch.INFRASTRUCTURE.ManagerConcretes;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<Category, CategoryDTO, ICategoryManager>
    {
        private ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager _categoryManager, IMapper mapper, ILoggerService service, ICategoryManager categoryManager) : base(_categoryManager, mapper, service)
        {
            this._categoryManager = categoryManager;
        }
        [HttpGet("active")]  // api/category/active şeklinde erişilebilir
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                _logger.LogInformationAsync("GetCategories metodu çalıştı");
                List<CategoryDTO> categories = await _categoryManager.GetCategories();

                if (categories == null || !categories.Any())
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Aktif kategori bulunamadı"
                    });
                }

                return Ok(new
                {
                    success = true,
                    data = categories,
                    message = "Aktif kategoriler başarıyla listelendi",
                    total = categories.Count
                });
            }
            catch (Exception ex)
            {
                _logger.LogErrorAsync($"GetCategories hatası: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Kategoriler listelenirken bir hata oluştu",
                    error = ex.Message
                });
            }
        }



    }
}
