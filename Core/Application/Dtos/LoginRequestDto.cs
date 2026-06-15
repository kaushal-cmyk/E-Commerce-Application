
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Application.Dtos
{
    public sealed record LoginRequestDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
