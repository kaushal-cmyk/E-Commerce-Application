#nullable enable
using ECommerce;

namespace ECommerce.Core.Application.Interface.Repositories;

public interface ICommandRepository<TEntity, TKey> : ICommandRepository<TEntity>
    where TEntity : class
    where TKey : notnull
{
    void Remove(TKey id);

    Task RemoveAsync(TKey id, CancellationToken cancellationToken = default (CancellationToken));
}