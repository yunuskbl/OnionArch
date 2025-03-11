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
    public abstract class BaseManager<TEntity, TDto> : IManager<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto
    {
        readonly IRepository<TEntity> _repository;
        readonly protected IMapper _mapper;

        protected BaseManager(IRepository<TEntity> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<string> CreateAsync(TDto entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = DataStatus.Inserted;
            
            TEntity domainEntity = _mapper.Map<TEntity>(entity);
            await _repository.CreateAsync(domainEntity);

            return "Ekleme Başarılı";
        }
        ///<summary>
        ///Veriyi Pasife Alır
        ///</summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<string> DeleteAsync(TDto entity)
        {

            entity.DeletedDate = DateTime.Now;
            entity.Status = DataStatus.Deleted;

            TEntity newValue = _mapper.Map<TEntity>(entity);
            TEntity originValue = await _repository.GetByIdAsync(newValue.Id);
            await _repository.UpdateAsync(originValue, newValue);
            return "Silme İşlemi Gerçekleşti";
        }

        public async Task<TDto> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            TEntity value =  await _repository.FirstOrDefaultAsync(expression);
            return _mapper.Map<TDto>(value);
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            List<TEntity> values = await _repository.GetAllAsync();
            return _mapper.Map<List<TDto>>(values);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            TEntity value = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(value);
        }

        /// <summary>
        /// Veriyi Tamamen Siler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> RemoveAsync(TDto entity)
        {
            if (entity.Status != DataStatus.Deleted)
            {
                return "Silme İşlemi Yalnızca Pasife Alınan Veriler Üzerinde Kullanılabilir";
            }

            TEntity orgValue = await _repository.GetByIdAsync(entity.Id);
            await _repository.DeleteAsync(orgValue);
            return $"{entity.Id} ID Numaralı Verinin Silme İşlemi Başarıyla Gerçekleşti";

        }

        public async Task<string> UpdateAsync(TDto entity)
        {
            entity.ModifiedDate= DateTime.Now;
            entity.Status = DataStatus.Updated;
            TEntity newValue = _mapper.Map<TEntity>(entity);
            TEntity orgValue = await _repository.GetByIdAsync(entity.Id);
            await _repository.UpdateAsync(orgValue, newValue);
            return "Güncelleme İşlemi Başarıyla Gerçekleşti";
        }

        public IQueryable<TDto> Where(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> values =  _repository.Where(expression);
            return _mapper.Map<IQueryable<TDto>>(values);
        }

        public async Task MakePassiveAsync(TDto entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.Status = DataStatus.Deleted;

            TEntity newValue = _mapper.Map<TEntity>(entity);
            TEntity originValue = await _repository.GetByIdAsync(newValue.Id);
            await _repository.UpdateAsync(originValue, newValue);
        }
    }
}
