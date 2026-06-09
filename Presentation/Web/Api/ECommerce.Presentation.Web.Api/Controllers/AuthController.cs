using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

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


        //[HttpPost("logout")]
        //[Authorize]
        //public async Task<IActionResult> Logout([FromBody] LoginRequestDto dto)
        //{

        //}

    }
}
