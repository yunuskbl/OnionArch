using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionArch.APPLICATION.DTOs.Categories;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;
using OnionArch.PERSISTENCE.ContextClasses;

namespace OnionArch.PERSISTENCE.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        
        MyContext _myContext;
        public CategoryRepository(MyContext context, MyContext myContext) : base(context)
        {
            _myContext = myContext;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories =  await _myContext.Set<Category>().Where(p=>p.Status!=DOMAIN.Enums.DataStatus.Deleted).ToListAsync();
            return categories;
        }
    }
}
