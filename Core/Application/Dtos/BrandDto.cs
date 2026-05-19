
namespace ECommerce.Core.Application.Dtos
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
