
using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Entities.Authentication
{
    public class RefreshToken : BaseEntity<Guid>
    {
        #region Fields and Properties
        public Guid UserId { get; private set; }
        public string TokenHash { get; private set; }
        public DateTimeOffset? RevokedAt { get; private set; }
        public DateTimeOffset ExpiresAt { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }

        public bool IsExpired => DateTimeOffset.Now >= ExpiresAt;
        public bool IsRevoked => RevokedAt != null;
        public bool IsActive => !IsExpired && !IsRevoked;

        #endregion

        #region Constructors

#nullable enable
        protected RefreshToken() { }
#nullable disable

        private RefreshToken(Guid userId, string tokenHash, DateTimeOffset expiresAt)
        {
            UserId = userId;
            TokenHash = tokenHash;
            ExpiresAt = expiresAt;
            CreatedAt = DateTimeOffset.Now;
        }
        #endregion

        #region Actions and Behaviours

        public static RefreshToken Create(Guid userId, string tokenHash, DateTimeOffset expiresAt)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(tokenHash);
            return new RefreshToken(userId, tokenHash, expiresAt);
        }

        public void RevokeToken()
        {
            RevokedAt = DateTimeOffset.Now;
        }
        #endregion
    }
}
