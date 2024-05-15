using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDTO userLogin)
        {
            try
            {
                var token = await userAuthService.Login(userLogin);

                return Ok(token);
            }
            catch (InvalidCredentialsException e)
            {
                return Unauthorized(new ErrorModel(e.Message, StatusCodes.Status401Unauthorized));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<string>> Register([FromBody] UserRegisterDTO userRegister)
        {
            try
            {
                var token = await userAuthService.Register(userRegister);

                return CreatedAtAction(nameof(Login), token);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
