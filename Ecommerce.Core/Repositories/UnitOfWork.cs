using Ecommerce.Domain.Common;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;
        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }
        public IUserRepository Users { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
