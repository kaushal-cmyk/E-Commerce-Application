using AutoMapper;
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Interface;
using ECommerce.Core.Application.Interface.Repositories;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.Errors;
using ECommerce.Core.Domain.Primitives;

namespace ECommerce.Core.Application.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Brand, Guid> _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(
            IUnitOfWork unitOfWork,
            IRepository<Brand, Guid> brandRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<Result<BrandDto>> GetBrand(Guid id, CancellationToken ct = default)
        {
            var brand = await _brandRepository.GetByIdAsync(id, ct);

            if (brand == null)
            {
                return Result<BrandDto>.Failure(RuntimeErrors.NullEntity);
            }

            var brandDto = _mapper.Map<BrandDto>(brand);
            return Result<BrandDto>.Success(brandDto);
        }

        public async Task<Result<IEnumerable<BrandDto>>> GetAllBrand(CancellationToken ct = default)
        {
            var brands = await _brandRepository.GetAllAsync(ct);

            if (brands == null)
            {
                return Result<IEnumerable<BrandDto>>.Failure(RuntimeErrors.NullEntity);
            }

            var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);

            return Result<IEnumerable<BrandDto>>.Success(brandDtos);
        }

        public async Task<Result<BrandDto>> CreateBrand(CreateBrandDto brandDto, CancellationToken ct = default)
        {
            var brand = Brand.Create(
                name: brandDto.Name,
                logoUrl: brandDto.LogoUrl);

            await _brandRepository.AddAsync(brand, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            var resultDto = _mapper.Map<BrandDto>(brand);
            return Result<BrandDto>.Success(resultDto);
        }

        public async Task<Result<BrandDto>> UpdateBrand(UpdateBrandDto brandDto, CancellationToken ct = default)
        {
            var brand = await _brandRepository.GetByIdAsync(brandDto.Id, ct);

            if (brand == null)
            {
                return Result<BrandDto>.Failure(RuntimeErrors.NullEntity);
            }

            brand.UpdateDetails(brandDto.Name, brandDto.LogoUrl);
            await _unitOfWork.SaveChangesAsync(ct);

            var resultDto = _mapper.Map<BrandDto>(brand);
            return Result<BrandDto>.Success(resultDto);
        }

        public async Task<Result> DeleteBrand(Guid id, CancellationToken ct = default)
        {
            var brand = await _brandRepository.GetByIdAsync(id, ct);

            if (brand == null)
            {
                return Result.Failure(RuntimeErrors.NullEntity);
            }

            await _brandRepository.RemoveAsync(brand, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return Result.Success();
        }
    }
}