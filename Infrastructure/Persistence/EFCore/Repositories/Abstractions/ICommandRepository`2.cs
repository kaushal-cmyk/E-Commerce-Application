#nullable enable
namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;

public interface ICommandRepository<TEntity, TKey> : ICommandRepository<TEntity>
    where TEntity : class
    where TKey : notnull
{
    void Remove(TKey id);

    Task RemoveAsync(TKey id, CancellationToken cancellationToken = default (CancellationToken));
}