using ECommerce.Infrastructure.Persistence.EFCore.Abstractions;
using ECommerce.Infrastructure.Persistence.EFCore.Options;
using Microsoft.Extensions.Options;

namespace ECommerce.Infrastructure.Persistence.EFCore.Data
{
    public class DbInitilizer : IDbInitilizer
    {
        private readonly IOptions<DefaultRolesAndUserConfigurationOptions> _config;

        public DbInitilizer(
            IOptions<DefaultRolesAndUserConfigurationOptions> config)
        {
            _config = config;
        }
        public void Initilize()
        {

        }
    }
}
