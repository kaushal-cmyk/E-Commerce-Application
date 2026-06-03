
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Interface;
using ECommerce.Core.Application.Interface.Repositories;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Entities.Authentication;

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
                storeId: dto.StoreId);

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

            var hashedPassword = _hasher.Hash(dto.Password);
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
                expiresAt: DateTimeOffset.Now.AddDays(7));

            await _refreshToken.AddAsync(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = rawRefreshToken
            };
        }

        public async Task<AuthResponseDto> RefreshTokenAsync()
        {

        }


        public async Task LogoutAsync(string userId)
        {

        }


    }
}
