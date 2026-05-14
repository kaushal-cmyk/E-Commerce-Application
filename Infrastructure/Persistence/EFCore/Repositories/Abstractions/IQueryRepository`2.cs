#nullable enable
namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;

public interface IQueryRepository<TEntity, TKey> : IQueryRepository<TEntity> 
    where TEntity : class
    where TKey : notnull 
{
    TEntity? GetById(TKey id);

    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
}