namespace Ecommerce.API.DTOs.UserDto
{
    public class UserDto
    {
        public required string Phone { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get;  set; }
        public required string Password { get; set; }
    }
}
