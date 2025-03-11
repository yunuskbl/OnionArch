using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.APPLICATION.DTOs.Categories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.APPLICATION.Managers
{
    public interface ICategoryManager : IManager<Category, CategoryDTO>
    {
        Task<List<CategoryDTO>> GetCategories();
    }
}
