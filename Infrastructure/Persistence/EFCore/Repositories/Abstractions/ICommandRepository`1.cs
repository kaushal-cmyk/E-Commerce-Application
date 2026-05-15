
#nullable enable
namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;

public interface ICommandRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

    TEntity Add(TEntity entity);

    TEntity Update(TEntity entity);

    void Remove(object id);
    void Remove(object?[]? id);

    void Remove(TEntity entity);

    Task AddRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default(CancellationToken));

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    Task RemoveAsync(object?[]? id, CancellationToken cancellationToken = default(CancellationToken));

    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
}