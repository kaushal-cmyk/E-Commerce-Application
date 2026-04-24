using System.Diagnostics.CodeAnalysis;
using ECommerce.Infrastructure.Persistance.EFCore.Abstractions;

#nullable enable
namespace E_commerce.Infrastructure.Persistance.EFCore.Abstractions;

public interface IQueryRepository<TEntity, TKey> : IQueryRepository<TEntity> 
    where TEntity : class
    where TKey : notnull
{
    TEntity? GetById(TKey id);

    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
}