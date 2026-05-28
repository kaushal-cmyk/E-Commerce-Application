
using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities.Authentication
{
    public class UserRole : BaseEntity<Guid>
    {
        #region Fields and Properties

        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }

        #endregion

        #region Constructors

#nullable disable
        protected UserRole() { }
#nullable enable

        private UserRole(Guid userId, Guid roleId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            RoleId = roleId;
        }

        #endregion

        #region Actions and Behaviours

        public static UserRole Create(Guid userId, Guid roleId)
        {
            return new UserRole(userId, roleId);
        }

        #endregion
    }
}
