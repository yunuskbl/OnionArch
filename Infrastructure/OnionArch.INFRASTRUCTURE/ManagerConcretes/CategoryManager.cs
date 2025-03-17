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
        IMapper _mapper;

<<<<<<< HEAD
        public CategoryManager(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
=======
        public CategoryManager(ICategoryRepository repository,IMapper mapper):base(repository,mapper)
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategories()
<<<<<<< HEAD
        {            
=======
        {
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
            var categories =  await _repository.GetCategories();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }
    }
}
