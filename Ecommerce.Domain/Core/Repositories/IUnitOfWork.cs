﻿using Ecommerce.Domain.Core.Models;

namespace Ecommerce.Domain.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        Task RollBackChangesAsync();
        IBaseRepository<T> Repository<T>() where T : BaseEntity;
    }
}
