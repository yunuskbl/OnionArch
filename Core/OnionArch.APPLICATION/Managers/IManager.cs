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
    public interface IManager<D ,T > where D : class,IEntity where T : class,IDto  
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IQueryable<T>> WhereAsync(Expression<Func<D, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<D, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<D, bool>> expression);
            
        Task<string> CreateAsync(T entity);
        Task<string> UpdateAsync(T entity);
        Task<string> DeleteAsync(T entity);
        Task<string> RemoveAsync(T entity);
    }
}
