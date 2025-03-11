using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.Categories;
using OnionArch.APPLICATION.Managers;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager= categoryManager;
        }
        [HttpGet("api/get-categories")]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryDTO> categories = await _categoryManager.GetCategories();
            return Ok(categories);
        }
        [HttpGet("api/get-all-categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            List<CategoryDTO> categories = await _categoryManager.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("api/get-category-by-id")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            CategoryDTO category= await _categoryManager.GetByIdAsync(id);
            return Ok(category);
        }

        //Request Model
        [HttpPost("api/add-category")]
        public async Task<IActionResult> CreateCategory(CategoryDTO category)
        {
            // Request Model üzerinden validation logic işlemi yapılır.Sonra requestModel, CategoryDTO'ya maplenir
            // ve CategoryDTO'ya gönderilir

            await _categoryManager.CreateAsync(category);
            return Ok("Category Eklendi");
        }
        [HttpPut("api/update")]
        public async Task<IActionResult> UpdateCategory(CategoryDTO category)
        {
            await _categoryManager.UpdateAsync(category);
            return Ok($"{category.Id} ID numaralı Kategori güncellendi");
        }
        [HttpPut("api/delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            CategoryDTO category = await _categoryManager.GetByIdAsync(id);
            await _categoryManager.DeleteAsync(category);
            return Ok("Silindi");
        }
        [HttpDelete("api/remove")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            CategoryDTO category = await _categoryManager.GetByIdAsync(id);
            string message = await _categoryManager.RemoveAsync(category);

            return Ok(message);
        }

    }
}
