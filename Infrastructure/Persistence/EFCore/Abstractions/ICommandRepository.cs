using System.Collections.Generic;

namespace ECommerce.Infrastructure.Persistance.EFCore.Abstractions;

public interface ICommandRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

    TEntity Add(TEntity entity);

    TEntity Update(TEntity entity);

    void Remove(object id);

    void Remove(object?[]? id);

    void Remove(TEntity entity);

    Task<IEnumerable<TEntity>> AddRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    
    Task RemoveAsync(object id, CancellationToken cancellationToken = default(CancellationToken));
    
    Task RemoveAsync(object?[]? id, CancellationToken cancellationToken = default(CancellationToken));
    
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
}