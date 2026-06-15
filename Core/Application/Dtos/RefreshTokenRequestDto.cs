
namespace ECommerce.Core.Application.Dtos
{
    public sealed record RefreshTokenRequestDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
