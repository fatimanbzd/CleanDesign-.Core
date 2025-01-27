﻿using Ecommerce.Domain.Core.Specifications;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Specifications
{
    public class AuthSpecifications
    {
        public static BaseSpecification<User> GetUserByEmailAndPasswordSpec(string email, string password)
        {
            return new BaseSpecification<User>(x => x.Email == email && x.PasswordHash == password && x.IsDeleted == false);
        }



        //public static BaseSpecification<User> GetAllActiveUsersSpec()
        //{
        //    return new BaseSpecification<User>(x => x.Status == UserStatus.Active && x.IsDeleted == false);
        //}
    }
}
