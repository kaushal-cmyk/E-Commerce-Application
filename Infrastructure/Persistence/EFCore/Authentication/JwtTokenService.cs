using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Entities.Authentication;
using System.Security.Claims;

namespace ECommerce.Infrastructure.Persistence.EFCore.Authentication
{
    public class JwtTokenService : IJwtTokenService
    {
        public string GenerateAccessToken(User user)
        {

        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {

        }

    }
}
