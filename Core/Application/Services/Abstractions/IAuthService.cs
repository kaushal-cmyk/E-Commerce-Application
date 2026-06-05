using ECommerce.Core.Application.Dtos;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto dto);
        Task RegisterAsync(RegisterUserDto dto);
        Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto dto);
        Task LogoutAsync(string userId, string rawRefreshToken);

        //Task<string> ValidateUserAsync(string email, string password);
    }
}
