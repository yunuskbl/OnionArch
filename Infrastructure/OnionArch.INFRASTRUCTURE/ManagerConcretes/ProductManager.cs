using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.Products;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class ProductManager:BaseManager<Product,ProductDTO>,IProductManager
    {
        IProductRepository _repository;
        IMapper _mapper;

        public ProductManager(IProductRepository repository,IMapper mapper):base(repository,mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProductOrderByAscAsync(bool ascending)
        {
            var products = await _repository.GetProductOrderByAscAsync(ascending);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int Id)
        {
            var products = await _repository.GetProductsByCategoryIdAsync(Id);
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
