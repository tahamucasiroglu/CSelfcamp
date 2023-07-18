using AutoMapper;
using NeDersinV2.Abstracts.Repository.Base;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.DTOs.Abstract;
using NeDersinV2.Entities.Abstract;
using NeDersinV2.Mapper;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Returns.Concrete;

namespace NeDersinV2.Services.Base
{
    abstract public class ServiceBase<Entity, Response, AddRequest, UpdateRequest> : ServiceBase<Entity, Response, AddRequest>, IService<Response, AddRequest, UpdateRequest>
        where Entity : class, IEntity, new()
        where Response : class, IGetDTO
        where AddRequest : class, I_VM_Create
        where UpdateRequest : class, I_VM_Update
    {

        public ServiceBase(IRepository<Entity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        
        public virtual IReturnModel<Response> Update(UpdateRequest entity)
        {
            IReturnModel<Entity> result = repository.Update(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual IReturnModel<IEnumerable<Response>> Update(IEnumerable<UpdateRequest> entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IReturnModel<Response>> UpdateAsync(UpdateRequest entity)
        {
            IReturnModel<Entity> result = await repository.UpdateAsync(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual Task<IReturnModel<IEnumerable<Response>>> UpdateAsync(IEnumerable<UpdateRequest> entity)
        {
            throw new NotImplementedException();
        }
    }

    abstract public class ServiceBase<Entity, Response, AddRequest> : ServiceBase<Entity, Response>, IService<Response, AddRequest>
        where Entity : class, IEntity, new()
        where Response : class, IGetDTO
        where AddRequest : class, I_VM_Create
    {
        public ServiceBase(IRepository<Entity> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public virtual IReturnModel<Response> Add(AddRequest entity)
        {
            IReturnModel<Entity> result = repository.Add(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual IReturnModel<IEnumerable<Response>> Add(IEnumerable<AddRequest> entity)
        {
            IReturnModel<IEnumerable<Entity>> result = repository.Add(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<Response>> AddAsync(AddRequest entity)
        {
            IReturnModel<Entity> result = await repository.AddAsync(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<IEnumerable<Response>>> AddAsync(IEnumerable<AddRequest> entity)
        {
            IReturnModel<IEnumerable<Entity>> result = await repository.AddAsync(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual IReturnModel<Response> Delete(int entity)
        {
            IReturnModel<Entity> result = repository.Delete(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual IReturnModel<IEnumerable<Response>> Delete(IEnumerable<int> entity)
        {
            IReturnModel<IEnumerable<Entity>> result = repository.Delete(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<Response>> DeleteAsync(int entity)
        {
            IReturnModel<Entity> result = await repository.DeleteAsync(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<IEnumerable<Response>>> DeleteAsync(IEnumerable<int> entity)
        {
            IReturnModel<IEnumerable<Entity>> result = await repository.DeleteAsync(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }
    }

    abstract public class ServiceBase<Entity, Response> : ServiceBase, IService<Response>
        where Entity : class, IEntity, new()
        where Response : class, IGetDTO
    {
        internal readonly IRepository<Entity> repository;
        internal readonly IMapper mapper;
        public ServiceBase(IRepository<Entity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual IReturnModel<IEnumerable<Response>> GetAll()
        {
            IReturnModel<IEnumerable<Entity>> result = repository.GetAll();
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<IEnumerable<Response>>> GetAllAsync()
        {
            IReturnModel<IEnumerable<Entity>> result = await repository.GetAllAsync();
            return ConvertToReturn<Response, Entity>(result, mapper);
        }
    }

    abstract public class ServiceBase
    {
        
        /// <summary>
        /// Tüm servis dönüşlerini kontrol etmek ve kolayca dönüştürmek için kullanılan yardımcı bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüştürülecek DTO tipini belirten IDto türetilmiş sınıf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiş sınıf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüştürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüşümünde kullanılacak IMapper nesnesi.</param> 
        /// <returns>Dönüştürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IReturnModel<TCheck> ConvertToReturn<TCheck, TEntity>(IReturnModel<TEntity> result, IMapper mapper)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null
                    ? new SuccessReturnModel<TCheck>("Data is null")
                    : new SuccessReturnModel<TCheck>(result.Data.ConvertToDtoCustom<TCheck>(mapper));
            }
            else
            {
                return new ErrorReturnModel<TCheck>(result.Message, null, result.Exception);
            }
        }
        /// <summary>
        /// Tüm servis dönüşlerini kontrol etmek ve kolayca dönüştürmek için kullanılan yardımcı bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüştürülecek DTO tipini belirten IDto türetilmiş sınıf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiş sınıf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüştürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüşümünde kullanılacak IMapper nesnesi.</param> 
        /// <returns>Dönüştürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IReturnModel<IEnumerable<TCheck>> ConvertToReturn<TCheck, TEntity>(IReturnModel<IEnumerable<TEntity>> result, IMapper mapper)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<IEnumerable<TCheck>>("Data is null") :
                    new SuccessReturnModel<IEnumerable<TCheck>>(result.Data.ConvertToDtoCustom<TCheck>(mapper));
            }
            else
            {
                return new ErrorReturnModel<IEnumerable<TCheck>>(result.Message, null, result.Exception);
            }
        }
    }


}
