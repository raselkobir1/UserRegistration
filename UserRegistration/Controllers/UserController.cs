using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.DataAccess.Entity;
using UserRegistration.DataAccess.UnitOfWorks;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;   
        public UserController(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        [HttpPost("user")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (user == null) { 
                return BadRequest();    
            }

            var result = await _unitOfWork.Users.AddAsync(user);  
            if(result > 1) { }
            return Ok("User registration succesfully done.");    
        }
    }
}
