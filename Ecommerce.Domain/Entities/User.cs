
using Ecommerce.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public sealed class User: BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        [Key]
        public int Id { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public  string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? Phone { get; set; }
        [Required]
        public EnumUserType UserType { get; set; }
        public long CreatedBy { get; set; } = 1;
        public DateTimeOffset CreatedOn { get; set; }= DateTimeOffset.Now;
        public Guid? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }= false;
        public User(string email, string password, string firstName, string lastName, string phone, EnumUserType userType)
        {
            Email = email;
            Password = password;
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
