using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.IServices
{
    public interface IGenericServiceAsync<TEntity, TDto> : IReadServiceAsync<TEntity, TDto>
      where TEntity : class
      where TDto : class

    {
        Task AddAsync(TDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(TDto dto);
    }
}
