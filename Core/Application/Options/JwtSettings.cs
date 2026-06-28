
namespace ECommerce.Core.Application.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; } = string.Empty;
        public int ExpiryMinutes { get; set; }
        public string Issueer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}
