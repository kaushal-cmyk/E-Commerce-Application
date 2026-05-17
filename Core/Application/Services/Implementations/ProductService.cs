
using AutoMapper;
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Infrastructure.Persistance.EFCore;
using ECommerce.Infrastructure.Persistance.EFCore.Repositories.Abstractions;

namespace ECommerce.Core.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }


        Task<ProductDto?> GetProduct(Guid id)
        {
            return;
        }
    }
}
