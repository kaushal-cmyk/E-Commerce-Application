
using ECommerce.Core.Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ECommerce.Core.Application.Services.Implementations
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserIdentity()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "System";
        }

        public string GetSignInName()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst("name")?.Value ?? "System";
        }

        public string GetPersonName()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst("given_name")?.Value ?? "System";
        }
    }
}
