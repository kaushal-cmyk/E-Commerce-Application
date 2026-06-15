
namespace ECommerce.Core.Application.Dtos
{
    public sealed record LogoutRequestDto
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
