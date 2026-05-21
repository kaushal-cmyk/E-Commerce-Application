
using AutoMapper;
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Interface;
using ECommerce.Core.Application.Interface.Repositories;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Entities;

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

        public async Task<BrandDto?> GetBrand(Guid id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrand()
        {
            var brand = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandDto>>(brand);
        }

        public async Task<BrandDto> CreateBrand(CreateBrandDto brandDto)
        {
            var brand = Brand.Create(
                name: brandDto.Name,
                logoUrl: brandDto.LogoUrl);

            await _brandRepository.AddAsync(brand);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BrandDto>(brand);
        }

    }
}
