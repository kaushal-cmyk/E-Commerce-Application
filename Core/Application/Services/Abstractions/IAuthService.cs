using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDto>> LoginAsync(LoginRequestDto dto);
        Task<Result> RegisterAsync(RegisterUserDto dto);
        Task<Result<AuthResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto dto);
        Task<Result> LogoutAsync(string userId, string rawRefreshToken);

        //Task<string> ValidateUserAsync(string email, string password);
    }
}
