
namespace ECommerce.Core.Application.Dtos
{
    public sealed record AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
