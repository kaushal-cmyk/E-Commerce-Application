
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Application.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public Guid StoreId { get; set; }
    }
}
