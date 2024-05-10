using DoctorClinicDALLibrary;
using DoctorClinicModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public class PatientBL : IPatientService
    {
        readonly IRepository<int,  Patient> _patientRepository;
        public PatientBL() {
            _patientRepository = new PatientRepository();
        }
        public Patient ChangePatientName(string PatientOldName, string PatientNewName)
        {
            throw new NotImplementedException();
        }

        public Doctor CreatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Patient DeletePatientById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetPatientAppointments(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
