﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Models.DTOs.AuthDto
{
    public class LoginDto
    {
        [Required]
        public required string email { get; set; }
        [Required]
        public required string password { get; set; }
    }
}
