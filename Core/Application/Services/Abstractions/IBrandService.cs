
using ECommerce.Core.Application.Dtos;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IBrandService
    {
        Task<BrandDto?> GetBrand(Guid id);
        Task<IEnumerable<BrandDto>> GetAllBrand();
        Task<BrandDto> CreateBrand(CreateBrandDto request);
        //Task<UpdateBrandDto> UpdateBrand(UpdateBrandDto request);
        //Task DeleteBrand(Guid id);
    }
}
