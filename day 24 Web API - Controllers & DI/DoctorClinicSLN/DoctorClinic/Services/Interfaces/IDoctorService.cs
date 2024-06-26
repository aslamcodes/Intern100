﻿using DoctorClinic.Models;

namespace DoctorClinic.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();

        Task<Doctor> UpdateDoctor(Doctor doctor);
    }
}
