
using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities.Authentication
{
    public class Role : BaseEntity<Guid>
    {
        #region Fields and Properties

        public string Name { get; private set; }

        #endregion

        #region Constructors

#nullable disable
        protected Role() { }
#nullable enable

        private Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion
    }
}
