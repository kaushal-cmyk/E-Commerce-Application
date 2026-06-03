
namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IHasher
    {
        string Hash(string value);
        bool Verify(string value, string hash);
    }
}
