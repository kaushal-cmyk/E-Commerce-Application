
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







    }
}
