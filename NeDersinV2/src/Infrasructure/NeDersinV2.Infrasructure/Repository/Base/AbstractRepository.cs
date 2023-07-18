using Microsoft.EntityFrameworkCore;
using NeDersinV2.Entities.Abstract;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Returns.Concrete;

namespace NeDersinV2.Infrasructure.Repository.Base
{
    abstract public class AbstractRepository<TEntity, TContext>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        internal readonly TContext context;
        public AbstractRepository(TContext context)
        {
            this.context = context;
        }
        internal virtual IReturnModel<TEntity> Save(TEntity entity)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return new SuccessReturnModel<TEntity>(entity);
                }
                return new ErrorReturnModel<TEntity>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<TEntity>(entity, e);
            }
        }

        internal virtual IReturnModel<IEnumerable<TEntity>> Save(IEnumerable<TEntity> entity)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return new SuccessReturnModel<IEnumerable<TEntity>>(entity);
                }
                return new ErrorReturnModel<IEnumerable<TEntity>>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<IEnumerable<TEntity>>(entity, e);
            }
        }
        internal virtual async Task<IReturnModel<TEntity>> SaveAsync(TEntity entity)
        {
            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new SuccessReturnModel<TEntity>(entity);
                }
                return new ErrorReturnModel<TEntity>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<TEntity>(entity, e);
            }
        }

        internal virtual async Task<IReturnModel<IEnumerable<TEntity>>> SaveAsync(IEnumerable<TEntity> entity)
        {
            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new SuccessReturnModel<IEnumerable<TEntity>>(entity);
                }
                return new ErrorReturnModel<IEnumerable<TEntity>>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<IEnumerable<TEntity>>(entity, e);
            }
        }

        internal virtual IReturnModel<TNull> CheckIsNull<TNull>(TNull? result)
            => (result == null) ? new ErrorReturnModel<TNull>() : new SuccessReturnModel<TNull>(result);
    }
}
