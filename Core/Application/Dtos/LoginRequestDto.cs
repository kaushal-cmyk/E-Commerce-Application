
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Application.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
