using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;
using OnionArch.PERSISTENCE.ContextClasses;

namespace OnionArch.PERSISTENCE.Repositories
{
    internal class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        MyContext _context;
        public ProductRepository(MyContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductOrderByAscAsync(bool ascending)
        {
            return ascending
                ? await _context.Products.OrderBy(p => p.UnitPrice).ToListAsync()
                : await _context.Products.OrderByDescending(p => p.UnitPrice).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int Id)
        {
            List<Product> products = await _context.Products.Where(p => p.CategoryId == Id).ToListAsync();
            
            return products;
        }
    }
}
