using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IProductManager _productManager;
        private readonly ILoggerService _loggerService;

        public ProductController(IProductManager manager, IMapper mapper, ILoggerService loggerService) : base(manager, mapper, loggerService)
        {
            _productManager = manager;
            _loggerService = loggerService;
        }

        [Authorize(Roles ="Manager,Admin")]
        public override Task<IActionResult> CreateAsync(ProductDTO dto)
        {
            return base.CreateAsync(dto);
        }

        [HttpGet("get-products-by-category-id")]
        public async Task<IActionResult> GetProductByCategoryIdAsync([FromQuery] int Id)
        {
            List<ProductDTO> products = await _productManager.GetProductsByCategoryIdAsync(Id);
            _logger.LogInformationAsync($"GetProductByCategoryIdAsync Metodu Çalıştı. \n " +
                $"Toplam Kayıt : {products.Count}");
            return Ok(new
            {
                success = true,
                data = products,
                total = products.Count
            });
        }
        [HttpGet("order-products")]
        public async Task<IActionResult> OrderProductsAsync([FromQuery] bool ascending)
        {
            var products = await _productManager.GetProductOrderByAscAsync(ascending);
            _loggerService.LogInformationAsync($"OrderProductsAsync Metodu Çalıştı. \n ");
            return Ok(new
            {
                success = true,
                data = products,
            });
        }


    }
}
