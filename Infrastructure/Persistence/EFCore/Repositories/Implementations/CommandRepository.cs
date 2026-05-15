using ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Implementations
{
    public class CommandRepository<TEntity, TKey> : ICommandRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public CommandRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            return entities;
        }

        public virtual TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public virtual void Remove(object id)
        {
            var val = _dbSet.Find(id);
            if (val != null)
            {
                _dbSet.Remove(val);
            }
        }

        public virtual void Remove(object?[]? ids)
        {
            var entity = _dbSet.Find(ids);
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(ids), "Entity not found.");
            }
            _dbSet.Remove(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual async Task RemoveAsync(object?[]? id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken);
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(id), "Entity not found.");
            }
            _dbSet.Remove(entity);
        }

        public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual void Remove(TKey id)
        {
            var entity = _dbSet.Find(id);
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(id), "Entity not found.");
            }
            _dbSet.Remove(entity);
        }
        public virtual async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken);
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(id), "Entity not found.");
            }
            _dbSet.Remove(entity);
        }
    }
}
