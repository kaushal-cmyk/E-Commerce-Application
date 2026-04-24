using ECommerce.Infrastructure.Persistance.EFCore.Abstractions;

#nullable enable
namespace E_commerce.Infrastructure.Persistance.EFCore.Abstractions;

public interface ICommandRepository<TEntity, TKey> : ICommandRepository<TEntity>
    where TEntity : class
    where TKey : notnull
{
    void Remove(TKey id);

    Task RemoveAsync(TKey id, CancellationToken cancellationToken = default (CancellationToken));
}