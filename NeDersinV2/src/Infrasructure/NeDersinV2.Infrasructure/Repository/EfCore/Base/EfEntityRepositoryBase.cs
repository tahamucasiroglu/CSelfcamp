using Microsoft.EntityFrameworkCore;
using NeDersinV2.Abstracts.Repository.Base;
using NeDersinV2.Entities.Abstract;
using NeDersinV2.Infrasructure.Repository.Base;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Returns.Concrete;
using System.Linq;
using System.Linq.Expressions;

namespace NeDersinV2.Infrasructure.Repository.EfCore.Base
{
    abstract public class EfEntityRepositoryBase<TEntity, TContext> : AbstractRepository<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public EfEntityRepositoryBase(TContext context) : base(context) { }
        public virtual IReturnModel<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return Save(entity);
        }

        public virtual async Task<IReturnModel<TEntity>> AddAsync(TEntity entity)
        {

            await context.Set<TEntity>().AddAsync(entity);
            return await SaveAsync(entity);

        }

        public virtual IReturnModel<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().AddRange(entity);
            return Save(entity);
        }

        public virtual async Task<IReturnModel<IEnumerable<TEntity>>> AddAsync(IEnumerable<TEntity> entity)
        {
            await context.Set<TEntity>().AddRangeAsync(entity);
            return await SaveAsync(entity);
        }

        public virtual IReturnModel<TEntity> Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return Save(entity);
        }

        public virtual async Task<IReturnModel<TEntity>> DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return await SaveAsync(entity);
        }

        public virtual IReturnModel<IEnumerable<TEntity>> Delete(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().RemoveRange(entity);
            return Save(entity);
        }

        public virtual async Task<IReturnModel<IEnumerable<TEntity>>> DeleteAsync(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().RemoveRange(entity);
            return await SaveAsync(entity);
        }

        public virtual IReturnModel<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            var result = context.Set<TEntity>().AsNoTracking().FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public virtual async Task<IReturnModel<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }

        public virtual IReturnModel<IEnumerable<TEntity>> _GetAll<TOrder>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null)
        {
            IQueryable<TEntity> result = context.Set<TEntity>().AsNoTracking();
            if (filter != null) result = result.Where(filter);
            if (order != null) result = result.OrderBy(order);
            if (TakeRange != null) result = result.Take((Range)TakeRange);
            if (Reserve) result = result.Reverse();
            return new SuccessReturnModel<IEnumerable<TEntity>>("Başarıyla Getirildi", result);
        }

        public virtual async Task<IReturnModel<IEnumerable<TEntity>>> _GetAllAsync<TOrder>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null)
        {
                //zoraki async
                IQueryable<TEntity> result = context.Set<TEntity>().AsNoTracking();
                if (filter != null) result = result.Where(filter);
                if (order != null) result = result.OrderBy(order);
                if (TakeRange != null) result = result.Take((Range)TakeRange);
                if (Reserve) result = result.Reverse();

                return await Task.FromResult(new SuccessReturnModel<IEnumerable<TEntity>>("Başarıyla Getirildi", result));
           
            
        }

        public virtual IReturnModel<TEntity> Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return Save(entity);
        }

        public virtual async Task<IReturnModel<TEntity>> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await SaveAsync(entity);
        }

        public virtual IReturnModel<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().UpdateRange(entity);
            return Save(entity);
        }

        public virtual async Task<IReturnModel<IEnumerable<TEntity>>> UpdateAsync(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().UpdateRange(entity);
            return await SaveAsync(entity);
        }

        public virtual IReturnModel<bool> IsExist(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return new SuccessReturnModel<bool>(context.Set<TEntity>().AsNoTracking().Any(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<bool>(e);
            }
        }

        public virtual async Task<IReturnModel<bool>> IsExistAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return new SuccessReturnModel<bool>(await context.Set<TEntity>().AsNoTracking().AnyAsync(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<bool>(e);
            }
        }
        public virtual IReturnModel<int> Count(Expression<Func<TEntity, bool>>? filter = null)
        {
            try
            {
                return new SuccessReturnModel<int>(filter == null ? context.Set<TEntity>().AsNoTracking().Count() : context.Set<TEntity>().AsNoTracking().Count(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<int>(e);
            }
        }
        public virtual async Task<IReturnModel<int>> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            try
            {
                return new SuccessReturnModel<int>(filter == null ? await context.Set<TEntity>().AsNoTracking().CountAsync() : await context.Set<TEntity>().AsNoTracking().CountAsync(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<int>(e);
            }
        }
    }
}