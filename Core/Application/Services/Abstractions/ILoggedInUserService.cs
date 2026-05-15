
namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface ILoggedInUserService
    {
        string GetCurrentUserIdentity();

        string GetSignInName();

        string GetPersonName();
    }
}
