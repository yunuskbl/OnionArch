﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.CONTRACT.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<List<Product>> GetProductsByCategoryIdAsync(int Id);
        Task<List<Product>> GetProductOrderByAscAsync(bool ascending);
    }
}
