using DoctorClinic.Exceptions;
using DoctorClinic.Models;
using DoctorClinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors([FromQuery] int? experience, [FromQuery] string? specialisation, IDoctorService doctorService)
        {
            try
            {
                var doctors = await doctorService.GetDoctors();

                if (experience.HasValue)
                {
                    doctors = doctors.Where(d => d.Experience >= experience);
                }

                if (!string.IsNullOrEmpty(specialisation))
                {
                    doctors = doctors.Where(d => d.Specialisation == specialisation);
                }

                return Ok(doctors);
            }
            catch (NoDoctorsFoundException)
            {
                return NoContent();
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctor(Doctor doctor, IDoctorService doctorService)
        {
            try
            {
                var updatedDoctor = await doctorService.UpdateDoctor(doctor);

                return Ok(updatedDoctor);
            }
            catch (DoctorNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
