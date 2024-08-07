﻿
using DoctorClinic.Context;
using DoctorClinic.Exceptions;
using DoctorClinic.Models;
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

            int rows = await context.SaveChangesAsync();

            if (rows == 0)
            {
                throw new DoctorNotFoundException();
            }

            return entity;
        }
    }
}
