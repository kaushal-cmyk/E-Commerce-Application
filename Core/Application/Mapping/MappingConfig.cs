using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Domain.Entities;

namespace ECommerce.Core.Application.Mapping
{
    public class MappingConfig : AutoMapper.Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Brand, BrandDto>();
        }
    }
}
