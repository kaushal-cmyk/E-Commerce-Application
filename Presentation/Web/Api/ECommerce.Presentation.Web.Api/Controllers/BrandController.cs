using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Domain.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Web.Api.Controllers;

[Authorize]
public class BrandController(IBrandService _brandService) : BaseApiController
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _brandService.GetBrand(id);

        if (!result.IsSuccess)
        {
            return NotFound(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _brandService.GetAllBrand();

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandDto request)
    {
        var result = await _brandService.CreateBrand(request);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Value.Id },
            result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBrandDto request)
    {
        var result = await _brandService.UpdateBrand(request);

        if (!result.IsSuccess)
        {
            return result.Error == DomainErrors.Brand.Errors.NotFound
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _brandService.DeleteBrand(id);

        if (!result.IsSuccess)
        {
            return result.Error == DomainErrors.Brand.Errors.NotFound
                ? NotFound(result.Error)
                : BadRequest(result.Error);
        }

        return NoContent();
    }
}