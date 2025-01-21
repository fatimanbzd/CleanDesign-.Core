using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Models.DTOs.UserDto
{
    public class LoginDto
    {
        [Required]
        public required string userName { get; set; }
        [Required]
        public required string password { get; set; }
    }
}
