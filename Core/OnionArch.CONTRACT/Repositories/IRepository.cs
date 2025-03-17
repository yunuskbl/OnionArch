using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.CONTRACT.Repositories
{
<<<<<<< HEAD
    
=======
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
    public interface IRepository<T> where T: class,IEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
<<<<<<< HEAD
        
=======
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        Task CreateAsync(T entity);
        Task UpdateAsync(T originEntity,T newEntity);
        Task DeleteAsync(T entity);

    }
}
