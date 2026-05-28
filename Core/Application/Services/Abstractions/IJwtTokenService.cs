
using ECommerce.Core.Domain.Entities.Authentication;
using System.Security.Claims;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(User user);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
