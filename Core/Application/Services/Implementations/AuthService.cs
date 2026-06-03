
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
        private readonly IHasher _tokenHasher;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(
            IRepository<User, Guid> userRepository,
            IRepository<RefreshToken, Guid> refreshToken,
            IJwtTokenService jwtTokenService,
            IHasher tokenHasher,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _refreshToken = refreshToken;
            _jwtTokenService = jwtTokenService;
            _tokenHasher = tokenHasher;
            _unitOfWork = unitOfWork;
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto login)
        {

            var email = await _userRepository.FindAsync(e => e.Email == login.Email);
            if (email != null)
            {
                throw new InvalidOperationException("Email already exists.");
            }



        }
    }
}

//Check email already exists → throw if it does
//2. Hash the password
//3. User.Create()
//4. Save to DB
//5. SaveChangesAsync
//6. Return success
