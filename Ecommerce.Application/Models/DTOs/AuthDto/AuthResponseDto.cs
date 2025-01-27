namespace Ecommerce.Application.Models.DTOs.AuthDto
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
