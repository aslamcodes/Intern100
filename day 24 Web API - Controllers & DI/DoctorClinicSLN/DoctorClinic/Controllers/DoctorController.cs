using DoctorClinic.Models;
using DoctorClinic.Services;
using DoctorClinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors(IDoctorService doctorService)
        {
            try
            {
                var doctors = await doctorService.GetDoctors();

                return Ok(doctors);
            }
            catch (NoDoctorsFoundException)
            {
                return NoContent();
            }
        }
    }
}
