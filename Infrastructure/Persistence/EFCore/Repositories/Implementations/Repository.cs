using ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Implementations
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>, IQueryRepository<TEntity, TKey>, ICommandRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        private readonly DbContext _context;
        private readonly QueryRepository<TEntity, TKey> _readRepository;

        private readonly CommandRepository<TEntity, TKey> _writeRepository;

        public Repository(DbContext context)
        {
            _context = context;
            _readRepository = new QueryRepository<TEntity, TKey>(_context);
            _writeRepository = new CommandRepository<TEntity, TKey>(_context);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _readRepository.Count(predicate);
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _readRepository.Any(predicate);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _readRepository.Get(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _readRepository.GetAll();
        }

        public virtual TEntity? Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _readRepository.Find(predicate);
        }

        public virtual TEntity? GetById(object id)
        {
            return _readRepository.GetById(id);
        }
        public virtual TEntity? GetById(TKey id)
        {
            return _readRepository.GetById(id);
        }

        public virtual TEntity? GetByIds(object?[]? ids)
        {
            return _readRepository.GetByIds(ids);
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readRepository.AnyAsync(predicate, cancellationToken);
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readRepository.CountAsync(predicate, cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readRepository.GetAsync(predicate, cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readRepository.GetAllAsync(cancellationToken);
        }

        public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readRepository.FindAsync(predicate, cancellationToken);
        }

        public virtual Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readRepository.GetByIdAsync(id, cancellationToken);
        }

        public virtual Task<TEntity?> GetByIdsAsync(object?[]? ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readRepository.GetByIdsAsync(ids, cancellationToken);
        }
        public virtual Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readRepository.GetByIdAsync(id, cancellationToken);
        }
        public virtual TEntity Add(TEntity entity)
        {
            return _writeRepository.Add(entity);
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return _writeRepository.AddRange(entities);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _writeRepository.Update(entity);
        }

        public virtual void Remove(object id)
        {
            _writeRepository.Remove(id);
        }

        public virtual void Remove(object?[]? id)
        {
            _writeRepository.Remove(id);
        }

        public virtual void Remove(TEntity entity)
        {
            _writeRepository.Remove(entity);
        }
        public void Remove(TKey id)
        {
            _writeRepository.Remove(id);
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _writeRepository.AddRangeAsync(entities, cancellationToken);
        }

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _writeRepository.AddAsync(entity, cancellationToken);
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _writeRepository.UpdateAsync(entity, cancellationToken);
        }

        public virtual Task RemoveAsync(object?[]? id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _writeRepository.RemoveAsync(id, cancellationToken);
        }

        public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _writeRepository.RemoveAsync(entity, cancellationToken);
        }

        public virtual Task RemoveAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _writeRepository.RemoveAsync(id, cancellationToken);
        }
    }
}
