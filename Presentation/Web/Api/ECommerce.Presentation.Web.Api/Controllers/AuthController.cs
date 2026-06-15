using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Presentation.Web.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authService.RegisterAsync(dto);
                return Ok("User Registered Successfully");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _authService.LoginAsync(dto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(
    RefreshTokenRequestDto request)
        {
            var result = await _authService.RefreshTokenAsync(request);
            return Ok(result);
        }


        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized("User ID claim not found.");
            }

            try
            {
                await _authService.LogoutAsync(userId, dto.RefreshToken);
                return Ok(new { Message = "Logged out successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
