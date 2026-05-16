
namespace ECommerce.Core.Domain.Common
{
    public abstract class BaseEntity<TKey> where TKey : notnull
    {
        public TKey Id { get; protected set; }
    }
}
