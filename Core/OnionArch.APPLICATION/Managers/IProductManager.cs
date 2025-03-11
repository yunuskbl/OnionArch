using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.APPLICATION.DTOs.Products;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.APPLICATION.Managers
{
    public interface IProductManager:IManager<Product,ProductDTO>
    {
        Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int Id);
        Task<List<ProductDTO>> GetProductOrderByAscAsync(bool ascending);
    }
}
