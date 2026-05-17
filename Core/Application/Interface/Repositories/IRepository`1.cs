#nullable enable
using ECommerce;

namespace ECommerce.Core.Application.Interface.Repositories;

public interface IRepository<TEntity> : IQueryRepository<TEntity>, ICommandRepository<TEntity> where TEntity : class
{
}