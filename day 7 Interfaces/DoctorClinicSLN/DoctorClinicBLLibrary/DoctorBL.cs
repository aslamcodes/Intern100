using DoctorClinicModelLib;
using DoctorClinicDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public class DoctorBL : IDoctorService
    {
        readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorBL()
        {
            _doctorRepository = new DoctorRepository();
        }

        public Doctor ChangeDoctorName(string DoctorOldName, string DoctorNewName)
        {
            throw new NotImplementedException();
        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Doctor DeleteDoctorByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetDoctorAppointments(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
