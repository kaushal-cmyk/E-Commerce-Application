using ECommerce.Infrastructure.Persistance.EFCore.Abstractions;

namespace E_commerce.Infrastructure.Persistance.EFCore.Abstractions;

public interface IRepository<TEntity, TKey> : 
    IRepository<TEntity>,
    IQueryRepository<TEntity>,
    ICommandRepository<TEntity>,
    IQueryRepository<TEntity, TKey>,
    ICommandRepository<TEntity, TKey>
    where TEntity : class
    where TKey : notnull
{
}