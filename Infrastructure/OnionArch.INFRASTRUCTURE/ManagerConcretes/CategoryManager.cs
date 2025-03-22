using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.Categories;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class CategoryManager : BaseManager<Category,CategoryDTO>,ICategoryManager
    {
        ICategoryRepository _repository;

        public CategoryManager(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            var categories =  await _repository.GetCategories();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }
    }
}
