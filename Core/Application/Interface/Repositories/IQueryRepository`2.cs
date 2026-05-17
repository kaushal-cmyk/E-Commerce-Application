#nullable enable
using ECommerce;

namespace ECommerce.Core.Application.Interface.Repositories;

public interface IQueryRepository<TEntity, TKey> : IQueryRepository<TEntity> 
    where TEntity : class
    where TKey : notnull 
{
    TEntity? GetById(TKey id);

    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
}