using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistance.Repositories;
public interface IAsyncRepository<TEntity,TEntityId>:IQuery<TEntity> where TEntity:Entity<TEntityId>
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity, bool permament = false);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);
    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent);
    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default);
    Task<Paginate<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default
        );
    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false, bool enableTracking = true,
        int index = 0, int size = 10,
        CancellationToken cancellationToken = default
        );
    Task<Paginate<TEntity>> GetListDynamicAsync(
        DynamicQuery dynamic,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false, bool enableTracking = true,
        int index = 0, int size = 10,
        CancellationToken cancellationToken = default
        );
}
