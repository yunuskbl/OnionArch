using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnionArch.APPLICATION.DTOs;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.APPLICATION.Managers
{
    public interface IManager<TEntity ,TDto > where TEntity : class,IEntity where TDto : class,IDto  
    {
        
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<IQueryable<TDto>> Where(Expression<Func<TEntity, bool>> expression);
        Task<TDto> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task MakePassiveAsync(TDto entity);
        Task<string> CreateAsync(TDto entity);
        Task<string> UpdateAsync(TDto entity);
        Task<string> DeleteAsync(TDto entity);
        Task<string> RemoveAsync(TDto entity);
        
    }
}
