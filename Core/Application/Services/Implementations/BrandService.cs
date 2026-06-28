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

        public async Task<Result<BrandDto>> GetBrand(Guid id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand == null)
            {
                return Result<BrandDto>.Failure(RuntimeErrors.NullEntity);
            }

            var brandDto = _mapper.Map<BrandDto>(brand);
            return Result<BrandDto>.Success(brandDto);
        }

        public async Task<Result<IEnumerable<BrandDto>>> GetAllBrand()
        {
            var brands = await _brandRepository.GetAllAsync();

            if (brands == null)
            {
                return Result<IEnumerable<BrandDto>>.Failure(RuntimeErrors.NullEntity);
            }

            var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);

            return Result<IEnumerable<BrandDto>>.Success(brandDtos);
        }

        public async Task<Result<BrandDto>> CreateBrand(CreateBrandDto brandDto)
        {
            var brand = Brand.Create(
                name: brandDto.Name,
                logoUrl: brandDto.LogoUrl);

            await _brandRepository.AddAsync(brand);
            await _unitOfWork.SaveChangesAsync();

            var resultDto = _mapper.Map<BrandDto>(brand);
            return Result<BrandDto>.Success(resultDto);
        }

        public async Task<Result<BrandDto>> UpdateBrand(UpdateBrandDto brandDto)
        {
            var brand = await _brandRepository.GetByIdAsync(brandDto.Id);

            if (brand == null)
            {
                return Result<BrandDto>.Failure(RuntimeErrors.NullEntity);
            }

            brand.UpdateDetails(brandDto.Name, brandDto.LogoUrl);
            await _unitOfWork.SaveChangesAsync();

            var resultDto = _mapper.Map<BrandDto>(brand);
            return Result<BrandDto>.Success(resultDto);
        }

        public async Task<Result> DeleteBrand(Guid id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand == null)
            {
                return Result.Failure(RuntimeErrors.NullEntity);
            }

            await _brandRepository.RemoveAsync(brand);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}