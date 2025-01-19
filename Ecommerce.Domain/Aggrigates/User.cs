
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Aggrigates
{
    public sealed class User
    {
        [Key]
        public int Id { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public  string Email { get; set; }
        public  string PasswordHash { get; set; }
        public string? Phone { get; set; }
        [Required]
        public EnumUserType UserType { get; set; }
        public User(string email, string passwordHash, string firstName, string lastName, string phone, EnumUserType userType)
        {
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            UserType = userType;
        }
    }

    public enum EnumUserType
    {
        Administrator = 1,
        Merchant = 2,
        Customer = 3
    }

}
