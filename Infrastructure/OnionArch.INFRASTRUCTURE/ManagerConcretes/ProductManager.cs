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
    public class ProductManager:BaseManager<Product,ProductsDTO>,IProductManager
    {
        IProductRepository _repository;

        public ProductManager(IProductRepository repository,IMapper mapper):base(repository,mapper)
        {
            _repository = repository;
        }
    }
}
