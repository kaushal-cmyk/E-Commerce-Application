
namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string passwork, string hash);
    }
}
