using FluentValidation;
using FluentValidation.Results;
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
        private readonly IValidator<User> _addValidator; 
        public UserController(IUnitOfWork unitOfWork, IValidator<User> addValidator)
        {
                _unitOfWork = unitOfWork;
                _addValidator = addValidator;
        }
        [HttpPost("user")] 
        public async Task<IActionResult> AddUser(User user)
        {
            if (user == null) { 
                return BadRequest();    
            }
            var validationResult = _addValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                return BadRequest(ConvertFluentErrorMessages(validationResult.Errors));
            }
            var userExits = await _unitOfWork.Users.GetByUserName(user.UserName);  
            if (userExits != null) 
                return Ok("User already exists for thsi user name");

            await _unitOfWork.Users.AddAsync(user);  
            return Ok("User created successfully");    
        }

        [NonAction]
        public static List<string> ConvertFluentErrorMessages(List<ValidationFailure> errors)
        {
            List<string> errorsMessages = new List<string>();
            foreach (var failure in errors)
            {
                errorsMessages.Add(failure.ErrorMessage);
            }
            return errorsMessages;
        }
    }
}
