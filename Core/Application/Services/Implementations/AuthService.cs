using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Interface;
using ECommerce.Core.Application.Interface.Repositories;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Entities.Authentication;
using ECommerce.Core.Domain.Enumerations;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ECommerce.Core.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IRepository<RefreshToken, Guid> _refreshToken;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IHasher _hasher;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(
            IRepository<User, Guid> userRepository,
            IRepository<RefreshToken, Guid> refreshToken,
            IJwtTokenService jwtTokenService,
            IHasher hasher,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _refreshToken = refreshToken;
            _jwtTokenService = jwtTokenService;
            _hasher = hasher;
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            var email = await _userRepository.FindAsync(e => e.Email == dto.Email);
            if (email != null)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            var hashedPassword = _hasher.Hash(dto.Password);

            var user = User.Create(
                username: dto.UserName,
                email: dto.Email,
                passwordHash: hashedPassword,
                storeId: Guid.Empty,
                role: UserRole.Customer);

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var user = await _userRepository.FindAsync(e => e.Email == dto.Email);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid credentials.");
            }

            var password = _hasher.Verify(dto.Password, user.PasswordHash);

            if (!password)
            {
                throw new InvalidOperationException("Invalid credentials.");
            }

            user.RecordLogin();
            var accessToken = _jwtTokenService.GenerateAccessToken(user);

            var rawRefreshToken = Guid.NewGuid().ToString();
            var hashedRefreshToken = _hasher.Hash(rawRefreshToken);

            var refreshToken = RefreshToken.Create(
                userId: user.Id,
                tokenHash: hashedRefreshToken,
                expiresAt: DateTimeOffset.UtcNow.AddDays(7));

            await _refreshToken.AddAsync(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = rawRefreshToken
            };
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto dto)
        {
            var principal = _jwtTokenService.GetPrincipalFromExpiredToken(dto.AccessToken);

            var userIdStr = principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new SecurityTokenException("Invalid token: missing user ID claim.");

            if (!Guid.TryParse(userIdStr, out var userId))
                throw new SecurityTokenException("Invalid token: malformed user ID.");

            var storedTokens = await _refreshToken.GetAsync(t => t.UserId == userId && t.IsActive);

            RefreshToken? storedToken = null;
            foreach (var token in storedTokens)
            {
                if (_hasher.Verify(dto.RefreshToken, token.TokenHash))
                {
                    storedToken = token;
                    break;
                }
            }

            if (storedToken == null)
                throw new InvalidOperationException("Invalid or expired refresh token.");

            var user = await _userRepository.FindAsync(u => u.Id == userId)
                ?? throw new InvalidOperationException("User not found.");

            storedToken.RevokeToken();

            var newAccessToken = _jwtTokenService.GenerateAccessToken(user);

            var newRawRefreshToken = Guid.NewGuid().ToString();
            var newHashedRefreshToken = _hasher.Hash(newRawRefreshToken);

            var newRefreshToken = RefreshToken.Create(
                userId: user.Id,
                tokenHash: newHashedRefreshToken,
                expiresAt: DateTimeOffset.UtcNow.AddDays(7));

            await _refreshToken.AddAsync(newRefreshToken);
            await _unitOfWork.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRawRefreshToken
            };
        }

        public async Task LogoutAsync(string userId, string rawRefreshToken)
        {
            if (!Guid.TryParse(userId, out var userGuid))
                throw new ArgumentException("Invalid userId.");

            var storedTokens = await _refreshToken.GetAsync(t => t.UserId == userGuid && t.IsActive);

            RefreshToken? storedToken = null;
            foreach (var token in storedTokens)
            {
                if (_hasher.Verify(rawRefreshToken, token.TokenHash))
                {
                    storedToken = token;
                    break;
                }
            }

            if (storedToken == null)
                throw new InvalidOperationException("Invalid refresh token.");

            storedToken.RevokeToken();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}