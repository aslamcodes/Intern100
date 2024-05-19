using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestTracker.Exceptions;
using RequestTracker.Models;
using RequestTracker.Models.DTO;
using RequestTracker.Services.Interfaces;

namespace RequestTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController(IRequestService _requestService) : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestReturnDto>> CreateRequest([FromBody] CreateRequestDto request)
        {
            try
            {
                var result = await _requestService.RaiseRequest(request);

                return Ok(result);
            }
            catch (UserNotEnabledException)
            {
                return Unauthorized(new ErrorModel("User is not active", 401));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ErrorModel("There is some problem with the input data", 400));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new ErrorModel(ex.Message, 400));
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<RequestReturnDto>>> GetRequestsAdmin()
        {
            try
            {
                var requests = await _requestService.GetAllRequestsForAdmin();

                return Ok(requests);
            }

            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, 400));
            }
        }


        [Authorize]
        [HttpGet("/user-requests")]
        public async Task<ActionResult<List<RequestReturnDto>>> GetRequestForUser(int userId)
        {

            try
            {
                var requests = await _requestService.GetAllRequestForUser(userId);

                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, 400));
            }

        }

    }
}
