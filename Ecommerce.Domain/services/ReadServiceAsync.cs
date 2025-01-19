using AutoMapper;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.services
{
    public class ReadServiceAsync<TEntity, TDto> : IReadServiceAsync<TEntity, TDto>
      where TEntity : class
      where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReadServiceAsync(IUnitOfWork unitOfWork, IMapper mapper) : base()
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.GenericRepository<TEntity>().GetAllAsync();

                if (result.Any())
                {
                    return _mapper.Map<IEnumerable<TDto>>(result);
                }
                else
                {
                    throw new EntityNotFoundException($"No {typeof(TDto).Name}s were found");
                }

            }
            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving all {typeof(TDto).Name}s";

                throw new EntityNotFoundException(message, ex);
            }
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.GenericRepository<TEntity>().GetByIdAsync(id);

                if (result is null)
                {
                    throw new EntityNotFoundException($"Entity with ID {id} not found.");
                }

                return _mapper.Map<TDto>(result);
            }

            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving {typeof(TDto).Name} with Id: {id}";

                throw new EntityNotFoundException(message, ex);
            }
        }
    }
}
