using ECommerce.Infrastructure.Persistance.EFCore.Abstractions;

#nullable enable
namespace ECommerce.Infrastructure.Persistance.EFCore.Abstractions;

public interface IRepository<TEntity> : IQueryRepository<TEntity>, ICommandRepository<TEntity> where TEntity : class
{
}