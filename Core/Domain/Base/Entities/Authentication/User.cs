
using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities.Authentication
{
    public class User : FullAuditedAggregateRoot<Guid>
    {

        #region Field and Properties

        public Guid StoreId { get; private set; }
        public string Email { get; private set; }

        public string PasswordHash { get; private set; }
        public bool IsVerified { get; private set; }
        public bool IsActive { get; private set; }

        public DateTimeOffset? LastLoginAt { get; private set; }

        #endregion


        #region Constructors

#nullable disable
        protected User() { }
#nullable enable

        private User(Guid storeId, string email, string passwordHash)
        {
            StoreId = storeId;
            Email = email;
            PasswordHash = passwordHash;
            IsVerified = false;
        }
        #endregion


        #region Actions and Behaviours

        public static User Create(Guid storeId, string email, string passwordHash)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(email);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(passwordHash);
            return new User(storeId, email, passwordHash);
        }

        public void VerifyUser()
        {
            IsVerified = true;
        }

        public void ActivateUser()
        {
            IsActive = true;
        }
        public void DeactivateUser()
        {
            IsActive = false;
        }
        public void RecordLogin()
        {
            LastLoginAt = DateTimeOffset.Now;
        }
        #endregion
    }
}
