using Ecommerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Aggregates
{
    public class User
    {
        [Key]

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? Phone { get; set; }
        public EnumUserType UserType { get; set; }
        public User(string email, string passwordHash, string firstName, string lastName)
        {
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;

        }


    }
}

public enum EnumUserType
{
    Administrator = 1,
    Editor = 2,
    General = 3
}
}
