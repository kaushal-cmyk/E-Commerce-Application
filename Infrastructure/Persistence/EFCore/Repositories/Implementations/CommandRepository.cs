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

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(object?[]? ids)
        {
            var entity = _dbSet.Find(ids);
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(ids), "Entity not found.");
            }
            _dbSet.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task RemoveAsync(object?[]? id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken);
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(id), "Entity not found.");
            }
            _dbSet.Remove(entity);
        }

        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public void Remove(TKey id)
        {
            var entity = _dbSet.Find(id);
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(id), "Entity not found.");
            }
            _dbSet.Remove(entity);
        }
        public async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default)
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
