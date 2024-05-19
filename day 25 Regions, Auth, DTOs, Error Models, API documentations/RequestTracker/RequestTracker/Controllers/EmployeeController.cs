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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(typeof(IList<EmployeeReturnDto>), statusCode: 200)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<EmployeeReturnDto>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();

                return Ok(employees.Select(e => e.ToEmployeeReturnDto()).ToList());
            }
            catch (NoEmployeesFoundException nefe)
            {
                return NotFound(new ErrorModel(nefe.Message, 404));
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut]
        public async Task<ActionResult<EmployeeReturnDto>> Put(int id, string phone)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee.ToEmployeeReturnDto());
            }
            catch (NoSuchEmployeeException nsee)
            {
                return NotFound(nsee.Message);
            }
        }

        [Authorize]
        [Route("GetEmployeeByPhone")]
        [HttpPost]
        public async Task<ActionResult<EmployeeReturnDto>> GetEmployeeByPhone([FromBody] GetEmployeeByPhoneInDto employeeDetails)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(employeeDetails.PhoneNumber);
                return Ok(employee.ToEmployeeReturnDto());
            }
            catch (NoSuchEmployeeException nefe)
            {
                return NotFound(nefe.Message);
            }
        }

    }
}

