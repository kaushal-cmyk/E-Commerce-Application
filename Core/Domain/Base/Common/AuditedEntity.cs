
using ECommerce.Core.Domain.ValueObjects;

namespace ECommerce.Core.Domain.Common
{
    public abstract class AuditedEntity<TKey> : BaseEntity<TKey> where TKey : notnull
    {
        public ActionInfo? Created { get; set; }
        public ActionInfo? Updated { get; set; }
    }
}
