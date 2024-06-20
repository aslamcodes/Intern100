using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Models.DTO;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class UserController(IUserAuthService userAuthService, ILogger<UserController> logger) : ControllerBase
    {
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthReturnDto), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<AuthReturnDto>> Login([FromBody] UserLoginDTO userLogin)
        {
            try
            {
                var user = await userAuthService.Login(userLogin);

                return Ok(user);
            }

            catch (UnauthorizedUserException e)
            {
                logger.LogError(e.Message);
                return Unauthorized(new ErrorModel(e.Message, StatusCodes.Status401Unauthorized));
            }
            catch (Exception e)
            {
                logger.LogError("Error while an user trying to log in -" + e.Message);
                return StatusCode(500);
            }
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthReturnDto), StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<AuthReturnDto>> Register([FromBody] UserRegisterDTO userRegister)
        {
            try
            {
                var user = await userAuthService.Register(userRegister);

                logger.LogInformation($"User {user.Id} has been registered.");
                return Ok(user);
            }

            catch (Exception e)
            {
                logger.LogError("Error while an user trying to register." + e.Message);
                return StatusCode(500);
            }
        }
    }
}
