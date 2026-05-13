#nullable enable
namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;

public interface IRepository<TEntity> : IQueryRepository<TEntity>, ICommandRepository<TEntity> where TEntity : class
{
}