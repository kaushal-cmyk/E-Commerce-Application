namespace ECommerce.Core.Application.Interface.Repositories;

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

public interface ICommandRepository<TEntity, TKey> : ICommandRepository<TEntity>
    where TEntity : class
    where TKey : notnull
{
    void Remove(TKey id);

    Task RemoveAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
}