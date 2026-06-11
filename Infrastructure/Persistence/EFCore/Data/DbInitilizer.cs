using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Entities.Authentication;
using ECommerce.Core.Domain.Enumerations;
using ECommerce.Infrastructure.Persistence.EFCore.Abstractions;
using ECommerce.Infrastructure.Persistence.EFCore.Authentication;
using ECommerce.Infrastructure.Persistence.EFCore.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ECommerce.Infrastructure.Persistence.EFCore.Data
{
    public class DbInitilizer : IDbInitilizer
    {
        private readonly IOptions<DefaultRolesAndUserConfigurationOptions> _config;
        private readonly EcomDBContext _db;
        private readonly IHasher _hasher;

        public DbInitilizer(
            EcomDBContext db,
            Hasher hasher,
            IOptions<DefaultRolesAndUserConfigurationOptions> config)
        {
            _db = db;
            _hasher = hasher;
            _config = config;
        }
        public void Initilize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }

                if (!_db.Users.Any())
                {
                    _db.Users.AddRange(
                        User.Create("superadmin", Guid.Empty, "superadmin@ecommerce.com", _hasher.Hash(_config.Value.DefaultSuperAdminPassword), UserRole.SuperAdmin),
                        User.Create("admin", Guid.Empty, "admin@ecommerce.com", _hasher.Hash(_config.Value.DefaultAdminPassword), UserRole.Admin),
                        User.Create("customer", Guid.Empty, "customer@ecommerce.com", _hasher.Hash(_config.Value.DefaultCustomerPassword), UserRole.Customer)
                    );
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
    }
}
