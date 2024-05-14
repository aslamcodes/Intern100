using DoctorClinic.Exceptions;
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

        public async Task<IEnumerable<Doctor>> GetDoctorsByExp(int numberOfYears)
        {

            try
            {
                var doctors = await repository.GetAll();

                return doctors.Where(d => d.Experience >= numberOfYears);
            }
            catch (NoDoctorsFoundException)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialisation(string specialisation)
        {

            try
            {
                var doctors = await repository.GetAll();

                return doctors.Where(d => d.Specialisation == specialisation);
            }
            catch (NoDoctorsFoundException)
            {
                throw;
            }

        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            try
            {
                await repository.Update(doctor);

                return doctor;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
