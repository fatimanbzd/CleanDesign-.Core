
using Ecommerce.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ecommerce.Domain.Entities
{
    public sealed class User : BaseEntity, ISoftDeleteEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string? Phone { get; set; }
        [Required]
        public EnumUserType UserType { get; set; }
        public long CreatedBy { get; set; } = 1;
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public bool IsDeleted { get; set; } = false;
        public User(string email, string password, string salt, string firstName, string lastName, string phone, EnumUserType userType)
        {
            Email = email;
            Password = password;
            Salt = salt;
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
