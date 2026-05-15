namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;

public interface IRepository<TEntity, TKey> : 
    IRepository<TEntity>,
    IQueryRepository<TEntity, TKey>,
    ICommandRepository<TEntity, TKey>
    where TEntity : class
    where TKey : notnull
{
}