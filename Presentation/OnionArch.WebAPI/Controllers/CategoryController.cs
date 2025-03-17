using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.Categories;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.INFRASTRUCTURE.CrossCuttingConcerns.Logging;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<Category, CategoryDTO, ICategoryManager>
    {

        public CategoryController(ICategoryManager manager,IMapper mapper,ILoggerService service): base(manager, mapper, service)
        {
        }
        [HttpGet("api/get-categories")]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryDTO> categories = await _manager.GetCategories();
            return Ok(categories);
        }
        [HttpGet("api/get-all-categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            List<CategoryDTO> categories = await _manager.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("api/get-category-by-id")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            CategoryDTO category= await _manager.GetByIdAsync(id);
            return Ok(category);
        }

        //Request Model
        [HttpPost("api/add-category")]
        public async Task<IActionResult> CreateCategory(CategoryDTO category)
        {
            // Request Model üzerinden validation logic işlemi yapılır.Sonra requestModel, CategoryDTO'ya maplenir
            // ve CategoryDTO'ya gönderilir

            await _manager.CreateAsync(category);
            return Ok("Category Eklendi");
        }
        [HttpPut("api/update")]
        public async Task<IActionResult> UpdateCategory(CategoryDTO category)
        {
            await _manager.UpdateAsync(category);
            return Ok($"{category.Id} ID numaralı Kategori güncellendi");
        }
        [HttpPut("api/delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            CategoryDTO category = await _manager.GetByIdAsync(id);
            await _manager.DeleteAsync(category);
            return Ok("Silindi");
        }
        [HttpDelete("api/remove")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            CategoryDTO category = await _manager.GetByIdAsync(id);
             string message = await _manager.RemoveAsync(category);

            return Ok(message);
        }

    }
}
