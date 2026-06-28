
using ECommerce.Core.Domain.POCOs;

namespace ECommerce.Core.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Authentication
        {
            public static class ErrorMessages
            {
                public static readonly string InvalidCredentials = "Invalid email or password";
                public static readonly string UserNotFound = "User not found";
                public static readonly string UserInActive = "Account is inactive";
                public static readonly string UserNotVerified = "Account is not verified";
                public static readonly string EmailAlreadyExists = "Email is already Registered";
                public static readonly string InvalidRefreshToken = "Invalid Token";
                public static readonly string RefreshTokenExpired = "Token expired";
                public static readonly string RefreshTokenRevoked = "Token Revoked";
            }

            public static class Errors
            {
                public static readonly Error InvalidCredentials =
                    new($"{nameof(Authentication)}.{nameof(InvalidCredentials)}", ErrorMessages.InvalidCredentials);

                public static readonly Error UserNotFound =
                    new($"{nameof(Authentication)}.{nameof(UserNotFound)}", ErrorMessages.UserNotFound);

                public static readonly Error UserInactive =
                    new($"{nameof(Authentication)}.{nameof(UserInactive)}", ErrorMessages.UserInActive);

                public static readonly Error UserNotVerified =
                    new($"{nameof(Authentication)}.{nameof(UserNotVerified)}", ErrorMessages.UserNotVerified);

                public static readonly Error EmailAlreadyExists =
                    new($"{nameof(Authentication)}.{nameof(EmailAlreadyExists)}", ErrorMessages.EmailAlreadyExists);

                public static readonly Error InvalidRefreshToken =
                    new($"{nameof(Authentication)}.{nameof(InvalidRefreshToken)}", ErrorMessages.InvalidRefreshToken);

                public static readonly Error RefreshTokenExpired =
                    new($"{nameof(Authentication)}.{nameof(RefreshTokenExpired)}", ErrorMessages.RefreshTokenExpired);

                public static readonly Error RefreshTokenRevoked =
                    new($"{nameof(Authentication)}.{nameof(RefreshTokenRevoked)}", ErrorMessages.RefreshTokenRevoked);
            }
        }
        public static class Product
        {
            public static class ErrorMessage
            {
                public static readonly string NotFound = "Product not found";

            }

            public static class Errors
            {
                public static readonly Error NotFound =
                    new($"{nameof(Product)}.{nameof(NotFound)}", ErrorMessage.NotFound);
            }
        }
        public static class Brand
        {
            public static class ErrorMessage
            {
                public static readonly string NotFound = "Brand not Found";
            }

            public static class Errors
            {
                public static readonly Error NotFound =
                    new($"{nameof(Brand)}.{nameof(NotFound)}", ErrorMessage.NotFound);
            }
        }
    }
}
