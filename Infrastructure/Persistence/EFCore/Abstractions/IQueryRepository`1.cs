using System.Linq.Expressions;

#nullable enable
namespace ECommerce.Infrastructure.Persistance.EFCore.Abstractions;

#nullable enable
public interface IQueryRepository<TEntity> where TEntity : class
{
    int Count(Expression<Func<TEntity, bool>> predicate);
    
    bool Any(Expression<Func<TEntity, bool>> predicate);

    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

    IEnumerable<TEntity> GetAll();

    TEntity? Find(Expression<Func<TEntity, bool>> predicate);

    TEntity? GetById(object id);

    TEntity? GetByIds(object?[]? ids);

    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default(CancellationToken));
    
    Task<int> CountAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default(CancellationToken));

    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

    Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TEntity?> FindAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default(CancellationToken));
    
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    
    Task<TEntity?> GetByIdsAsync(object?[]? ids, CancellationToken cancellationToken = default(CancellationToken));
}