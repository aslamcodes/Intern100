
using DoctorClinic.Context;
using DoctorClinic.Models;
using DoctorClinic.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinic.Repository
{
    public class DoctorRepository(DoctorClinicContext context) : IRepository<int, Doctor>
    {
        public Task<Doctor> Add(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {

            var doctors = await context.Doctors.ToListAsync();

            if (doctors.Count == 0)
            {
                throw new NoDoctorsFoundException();
            }

            return doctors;
        }

        public Task<Doctor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> Update(Doctor entity)
        {
            context.Doctors.Update(entity);

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
