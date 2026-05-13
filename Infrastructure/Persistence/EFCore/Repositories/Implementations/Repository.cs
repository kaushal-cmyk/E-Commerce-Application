using ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Implementations
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly EcomDBContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(EcomDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Count(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }



    }
}
