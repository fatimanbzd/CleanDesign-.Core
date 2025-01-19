using Ecommerce.API.DTOs.UserDto;
using Ecommerce.Domain;
using Ecommerce.Domain.Aggrigates;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<bool>> Add(UserDto user)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.GenericRepository<UserDto>().AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

                return Ok(true);
            }
            return BadRequest(false);
        }
  
    }
}
