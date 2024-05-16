using Microsoft.AspNetCore.Mvc;
using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Models.DTO;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserAuthService userAuthService) : ControllerBase
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
                return Unauthorized(new ErrorModel(e.Message, StatusCodes.Status401Unauthorized));
            }
            catch (Exception)
            {
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

                return Ok(user);
            }

            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
