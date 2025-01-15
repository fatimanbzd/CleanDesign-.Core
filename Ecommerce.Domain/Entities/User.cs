
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entity
{
    public sealed class User
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string? Phone { get; set; }
        public required EnumUserType UserType { get; set; }
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
        Editor = 2,
        General = 3
    }

}
