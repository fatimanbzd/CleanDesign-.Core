
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
        public  string PasswordHash { get; set; }
        public string? Phone { get; set; }
        [Required]
        public EnumUserType UserType { get; set; }
        public long CreatedBy { get; set; } = 1;
        public DateTimeOffset CreatedOn { get; set; }= DateTimeOffset.Now;
        public Guid? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }= false;
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
