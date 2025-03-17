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
<<<<<<< HEAD
        
=======

>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        protected BaseManager(IRepository<TEntity> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

<<<<<<< HEAD
        public async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Bir Hata Oluştu ", ex);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await ExecuteAsync(async () =>
            {
                return await _repository.AnyAsync(expression);
            });

=======
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        }

        public async Task<string> CreateAsync(TDto entity)
        {
<<<<<<< HEAD
            return await ExecuteAsync(async () =>
            {
                entity.CreatedDate = DateTime.Now;
                entity.Status = DataStatus.Inserted;

                TEntity domainEntity = _mapper.Map<TEntity>(entity);
                await _repository.CreateAsync(domainEntity);

                return "Ekleme Başarılı";
            });
=======
            entity.CreatedDate = DateTime.Now;
            entity.Status = DataStatus.Inserted;
            
            TEntity domainEntity = _mapper.Map<TEntity>(entity);
            await _repository.CreateAsync(domainEntity);

            return "Ekleme Başarılı";
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        }
        ///<summary>
        ///Veriyi Pasife Alır
        ///</summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<string> DeleteAsync(TDto entity)
        {
<<<<<<< HEAD
            return await ExecuteAsync(async () =>
            {
                entity.DeletedDate = DateTime.Now;
                entity.Status = DataStatus.Deleted;

                TEntity newValue = _mapper.Map<TEntity>(entity);
                TEntity originValue = await _repository.GetByIdAsync(newValue.Id);
                await _repository.UpdateAsync(originValue, newValue);
                return "Silme İşlemi Gerçekleşti";
            });
=======

            entity.DeletedDate = DateTime.Now;
            entity.Status = DataStatus.Deleted;

            TEntity newValue = _mapper.Map<TEntity>(entity);
            TEntity originValue = await _repository.GetByIdAsync(newValue.Id);
            await _repository.UpdateAsync(originValue, newValue);
            return "Silme İşlemi Gerçekleşti";
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        }

        public async Task<TDto> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
<<<<<<< HEAD
            return await ExecuteAsync(async () =>
            {
                TEntity value = await _repository.FirstOrDefaultAsync(expression);
                return _mapper.Map<TDto>(value);
            });
=======
            TEntity value =  await _repository.FirstOrDefaultAsync(expression);
            return _mapper.Map<TDto>(value);
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        }

        public async Task<List<TDto>> GetAllAsync()
        {
<<<<<<< HEAD
            return await ExecuteAsync(async () =>
            {
                List<TEntity> values = await _repository.GetAllAsync();
                return _mapper.Map<List<TDto>>(values);
            });
=======
            List<TEntity> values = await _repository.GetAllAsync();
            return _mapper.Map<List<TDto>>(values);
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
<<<<<<< HEAD
            return await ExecuteAsync(async () =>
            {
                TEntity value = await _repository.GetByIdAsync(id);
                return _mapper.Map<TDto>(value);
            });
=======
            TEntity value = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(value);
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
        }

        /// <summary>
        /// Veriyi Tamamen Siler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> RemoveAsync(TDto entity)
        {
<<<<<<< HEAD
            return await ExecuteAsync(async () =>
            {
                if (entity.Status != DataStatus.Deleted)
                {
                    return "Silme İşlemi Yalnızca Pasife Alınan Veriler Üzerinde Kullanılabilir";
                }

                TEntity orgValue = await _repository.GetByIdAsync(entity.Id);
                await _repository.DeleteAsync(orgValue);
                return $"{entity.Id} ID Numaralı Verinin Silme İşlemi Başarıyla Gerçekleşti";
            });

=======
            if (entity.Status != DataStatus.Deleted)
            {
                return "Silme İşlemi Yalnızca Pasife Alınan Veriler Üzerinde Kullanılabilir";
            }

            TEntity orgValue = await _repository.GetByIdAsync(entity.Id);
            await _repository.DeleteAsync(orgValue);
            return $"{entity.Id} ID Numaralı Verinin Silme İşlemi Başarıyla Gerçekleşti";
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2

        }

        public async Task<string> UpdateAsync(TDto entity)
        {
<<<<<<< HEAD
            return await ExecuteAsync(async () =>
            {
                entity.ModifiedDate = DateTime.Now;
                entity.Status = DataStatus.Updated;
                TEntity newValue = _mapper.Map<TEntity>(entity);
                TEntity orgValue = await _repository.GetByIdAsync(entity.Id);
                await _repository.UpdateAsync(orgValue, newValue);
                return "Güncelleme İşlemi Başarıyla Gerçekleşti";
            });
        }

        public async Task<IQueryable<TDto>> Where(Expression<Func<TEntity, bool>> expression)
        {
            return await ExecuteAsync(async () =>
            {
                IQueryable<TEntity> values = _repository.Where(expression);
                return _mapper.Map<IQueryable<TDto>>(values);
            });
        }

=======
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
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
    }
}
