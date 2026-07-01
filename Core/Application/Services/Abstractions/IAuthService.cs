using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDto>> LoginAsync(LoginRequestDto dto, CancellationToken ct = default);
        Task<Result> RegisterAsync(RegisterUserDto dto, CancellationToken ct = default);
        Task<Result<AuthResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto dto, CancellationToken ct = default);
        Task<Result> LogoutAsync(string userId, string rawRefreshToken, CancellationToken ct = default);

        //Task<string> ValidateUserAsync(string email, string password);
    }
}
