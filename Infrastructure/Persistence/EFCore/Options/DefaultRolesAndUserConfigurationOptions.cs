namespace ECommerce.Infrastructure.Persistence.EFCore.Options
{
    public class DefaultRolesAndUserConfigurationOptions
    {
        public const string DefaultUserAndRole = "DefaultUserAndRole";

        public string DefaultSuperAdminUserName { get; set; } = string.Empty;

        public string DefaultSuperAdminUserEmail { get; set; } = string.Empty;

        public string DefaultSuperAdminPassword { get; set; } = string.Empty;

        public string DefaultAdminUserName { get; set; } = string.Empty;

        public string DefaultAdminUserEmail { get; set; } = string.Empty;

        public string DefaultAdminPassword { get; set; } = string.Empty;

        public string DefaultCustomerUserName { get; set; } = string.Empty;

        public string DefaultCustomerEmail { get; set; } = string.Empty;

        public string DefaultCustomerPassword { get; set; } = string.Empty;

    }
}
