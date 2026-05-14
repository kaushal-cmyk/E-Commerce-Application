
#nullable enable
namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;

public interface ICommandRepository<TEntity> where TEntity : class
{
    void AddRange(IEnumerable<TEntity> entities);

    void Add(TEntity entity);

    void Update(TEntity entity);

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