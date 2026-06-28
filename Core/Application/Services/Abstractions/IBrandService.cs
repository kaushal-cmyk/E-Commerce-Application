
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Abstractions
{
    public interface IBrandService
    {
        Task<Result<BrandDto>> GetBrand(Guid id, CancellationToken ct = default);
        Task<Result<IEnumerable<BrandDto>>> GetAllBrand(CancellationToken ct = default);
        Task<Result<BrandDto>> CreateBrand(CreateBrandDto request, CancellationToken ct = default);
        Task<Result<BrandDto>> UpdateBrand(UpdateBrandDto request, CancellationToken ct = default);
        Task<Result> DeleteBrand(Guid id, CancellationToken ct = default);
    }
}
