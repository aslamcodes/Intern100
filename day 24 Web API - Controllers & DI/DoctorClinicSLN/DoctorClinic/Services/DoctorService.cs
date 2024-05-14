using DoctorClinic.Models;
using DoctorClinic.Repository;
using DoctorClinic.Services.Interfaces;


namespace DoctorClinic.Services
{
    public class DoctorService(IRepository<int, Doctor> repository) : IDoctorService
    {

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {

            try
            {
                var doctors = await repository.GetAll();

                return doctors;
            }
            catch (NoDoctorsFoundException)
            {
                throw;
            }

        }
    }
}
