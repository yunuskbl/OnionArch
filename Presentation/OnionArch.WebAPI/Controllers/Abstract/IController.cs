using Microsoft.AspNetCore.Mvc;

namespace OnionArch.WebAPI.Controllers.Abstract
{
    public interface IController<TEntity, TDto, TManager>
    {
        public Task<IActionResult> GetAllAsync();
        public Task<IActionResult> GetByIdAsync(int id);
        public Task<IActionResult> CreateAsync(TDto dto);
        public Task<IActionResult> DeleteAsync(int id);
        public Task<IActionResult> UpdateAsync(TDto dto);
        public Task<IActionResult> RemoveAsync(int id);
    }
}
