using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var brand = await _brandService.GetBrand(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateBrandDto request)
        {
            var brand = await _brandService.CreateBrand(request);
            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
        }

        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetAllBrand()
        {
            var brands = await _brandService.GetAllBrand();
            return Ok(brands);
        }
    }
}
