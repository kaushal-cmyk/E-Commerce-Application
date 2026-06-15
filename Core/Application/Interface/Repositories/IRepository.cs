namespace ECommerce.Core.Application.Interface.Repositories;

public interface IRepository<TEntity> : IQueryRepository<TEntity>, ICommandRepository<TEntity> where TEntity : class
{
}
public interface IRepository<TEntity, TKey> :
    IRepository<TEntity>,
    IQueryRepository<TEntity, TKey>,
    ICommandRepository<TEntity, TKey>
    where TEntity : class
    where TKey : notnull
{
}