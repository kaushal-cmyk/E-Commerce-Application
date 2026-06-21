
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IBrandService
    {
        Task<Result<BrandDto>> GetBrand(Guid id);
        Task<Result<IEnumerable<BrandDto>>> GetAllBrand();
        Task<Result<BrandDto>> CreateBrand(CreateBrandDto request);
        Task<Result<BrandDto>> UpdateBrand(UpdateBrandDto request);
        Task<Result> DeleteBrand(Guid id);
    }
}
