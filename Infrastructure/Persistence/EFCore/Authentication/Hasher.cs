
using ECommerce.Core.Application.Services.Abstractions;

namespace ECommerce.Infrastructure.Persistence.EFCore.Authentication
{
    public class Hasher : IHasher
    {
        public string Hash(string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value);
        }

        public bool Verify(string value, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(value, hash);
        }
    }
}
