using ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.Persistance.EFCore.Repositories.Implementations
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
    }
}
