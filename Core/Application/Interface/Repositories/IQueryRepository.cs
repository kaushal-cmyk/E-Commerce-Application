using System.Linq.Expressions;

namespace ECommerce.Core.Application.Interface.Repositories
{
    public interface IQueryRepository<TEntity> where TEntity : class
    {
        int Count(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        TEntity? Find(Expression<Func<TEntity, bool>> predicate);

        TEntity? GetById(object id);
        TEntity? GetByIds(object?[]? ids);

        Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CountAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TEntity?> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity?> GetByIdsAsync(object?[]? ids, CancellationToken cancellationToken = default(CancellationToken));
    }

    public interface IQueryRepository<TEntity, TKey> : IQueryRepository<TEntity>
    where TEntity : class
    where TKey : notnull
    {
        TEntity? GetById(TKey id);

        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
