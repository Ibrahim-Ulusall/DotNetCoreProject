using Core.Persistance.Dynamic;
using Core.Persistance.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistance.Repositories;
public interface IRepository<TEntity, TEntityId> : IQuery<TEntity> where TEntity : Entity<TEntityId>
{
    TEntity Add(TEntity entity);
    TEntity Delete(TEntity entity, bool permanent = false);
    TEntity Update(TEntity entity);
    ICollection<TEntity> AddRange(ICollection<TEntity> entities);
    ICollection<TEntity> DeleteRange(ICollection<TEntity> entities, bool permanent = false);
    ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);
    TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false, bool enableTracking = true
        );
    Paginate<TEntity> GetList(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false, bool enableTracking = true,
        int index = 0, int size = 10
        );
    Paginate<TEntity> GetListDynamic(
        DynamicQuery dynamic,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false, bool enabledTracking = true,
        int index = 0, int size = 10
        );
    bool Any(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false, bool enableTracking = true
        );
}
