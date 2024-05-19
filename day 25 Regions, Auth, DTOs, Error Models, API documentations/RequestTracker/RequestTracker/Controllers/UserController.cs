using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestTracker.Exceptions;
using RequestTracker.Models;
using RequestTracker.Models.DTO;
using RequestTracker.Services.Interfaces;

namespace RequestTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(ex.Message, 401));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(EmployeeReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeReturnDto>> Register(EmployeeRegisterDto userDTO)
        {
            try
            {
                Employee result = await _userService.Register(userDTO);
                return Ok(result.ToEmployeeReturnDto());
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, 501));
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [Route("ActivateEmployee")]
        [HttpPut]
        public async Task<ActionResult<ActivationReturnDto>> ActivateUser([FromBody] ActivateUserDto employeeActivationDetails)
        {
            try
            {
                var activationResult = await _userService.ActivateUser(employeeActivationDetails);

                return Ok(activationResult);
            }
            catch (NoSuchEmployeeException nsee)
            {
                return NotFound(new ErrorModel(nsee.Message, 404));
            }
            catch (NoSuchUserException ex)
            {
                return NotFound(new ErrorModel(ex.Message, 404));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

