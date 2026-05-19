using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Application.Dtos;

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
