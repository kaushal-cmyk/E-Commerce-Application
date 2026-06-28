
namespace ECommerce.Core.Application.Options
{
    public sealed class JwtSettings
    {
        public string Secret { get; init; } = string.Empty;
        public int ExpiryMinutes { get; init; }
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
    }
}
