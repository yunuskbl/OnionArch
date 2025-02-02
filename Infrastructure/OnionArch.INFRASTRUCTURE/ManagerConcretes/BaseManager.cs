using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Abstracts;
using OnionArch.DOMAIN.Enums;


namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public abstract class BaseManager<D, T> : IManager<D, T> where D : class, IEntity where T : class, IDto
    {
        readonly IRepository<D> _repository;
        readonly protected IMapper _mapper;

        protected BaseManager(IRepository<D> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<D, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<string> CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = DataStatus.Inserted;
            
            D domainEntity = _mapper.Map<D>(entity);
            await _repository.CreateAsync(domainEntity);

            return "Ekleme Başarılı";
        }
        ///<summary>
        ///Veriyi Pasife Alır
        ///</summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<string> DeleteAsync(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.Status= DataStatus.Deleted;
            D newValue = _mapper.Map<D>(entity);
            D originalValue= await _repository.GetByIdAsync(newValue.Id);
            await _repository.UpdateAsync(originalValue,newValue);
            return "Veri Pasife Alınmıştır";
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<D, bool>> expression)
        {
            D value =  await _repository.FirstOrDefaultAsync(expression);
            return _mapper.Map<T>(value);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<D> values = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            D value = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(value);
        }

        /// <summary>
        /// Veriyi Tamamen Siler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> RemoveAsync(T entity)
        {
            if (entity.Status != DataStatus.Deleted)
            {
                return "Silme İşlemi Yalnızca Pasife Alınan Veriler Üzerinde Kullanılabilir";
            }
            D orgValue = await _repository.GetByIdAsync(entity.Id);
            await _repository.DeleteAsync(orgValue);
            return $"{entity.Id} ID Numaralı Verinin Silme İşlemi Başarıyla Gerçekleşti";

        }

        public async Task<string> UpdateAsync(T entity)
        {
            entity.ModifiedDate= DateTime.Now;
            entity.Status = DataStatus.Updated;
            D newValue = _mapper.Map<D>(entity);
            D orgValue = await _repository.GetByIdAsync(entity.Id);
            await _repository.UpdateAsync(orgValue, newValue);
            return "Güncelleme İşlemi Başarıyla Gerçekleşti";
        }

        public IQueryable<T> Where(Expression<Func<D, bool>> expression)
        {
            IQueryable<D> values =  _repository.Where(expression);
            return _mapper.Map<IQueryable<T>>(values);
        }
    }
}
