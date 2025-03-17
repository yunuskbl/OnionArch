using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.Products;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product, ProductDTO, IProductManager>
    {

        public ProductController(IProductManager manager,IMapper mapper,ILoggerService loggerService) : base(manager,mapper,loggerService)
        {
        }
        [HttpGet("api/get-all")]
        public async Task<IActionResult> GetAll()
        {
            List<ProductDTO> products = await _manager.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("api/get-by-product-id")]
        public async Task<IActionResult> GetByProductId([FromQuery] int Id)
        {
            ProductDTO products = await _manager.GetByIdAsync(Id);
            return Ok(products);
        }
        [HttpGet("api/get-products-by-price")]
        public async Task<IActionResult> GetProductOrderByAsc([FromQuery] bool ascending = true)
        {
            var products = await _manager.GetProductOrderByAscAsync(ascending);
            return Ok(products);
        }
        [HttpGet("api/get-products-by-category-id")]
        public async Task<IActionResult> GetProductByCategoryIdAsync([FromQuery] int Id)
        {
            List<ProductDTO> products = await _manager.GetProductsByCategoryIdAsync(Id);
            return Ok(products);
        }
        [HttpGet("api/order-products")]
        public async Task<IActionResult> OrderProductsAsync([FromQuery] bool ascending)
        {
            var products = await _manager.GetProductOrderByAscAsync(ascending);
            return Ok(products);
        }

        [HttpPost("api/add-product")]
        public async Task<IActionResult> AddProductAsync(ProductDTO product)
        {
            await _manager.CreateAsync(product);
            return Ok();
        }
        [HttpPut("api/update-product")]
        public async Task<IActionResult> UpdateProductAsync(ProductDTO product)
        {
            await _manager.UpdateAsync(product);
            return Ok($"{product.Id} ID Numaralı ürün bilgileri güncellendi.");
        }
        [HttpPut("api/delete-product")]
        public async Task<IActionResult> DeleteProductAsync(int Id)
        {
            ProductDTO product = await _manager.GetByIdAsync(Id);
            await _manager.DeleteAsync(product);
            return Ok();
        }
        [HttpDelete("api/remove-product")]
        public async Task<IActionResult> RemoveProductAsync(int Id)
        {
            ProductDTO product = await _manager.GetByIdAsync(Id);
            string message = await _manager.RemoveAsync(product);
            return Ok(message);
        }
    }
}
