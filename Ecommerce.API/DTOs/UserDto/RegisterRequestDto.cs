﻿namespace Ecommerce.API.DTOs.UserDto
{
    public class RegisterRequestDto
    {

        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
