using DoctorClinicModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public interface IPatientService
    {
        Doctor CreatePatient(Patient patient);

        Patient ChangePatientName(string PatientOldName, string PatientNewName);

        Patient GetPatientById(int id);

        List<Appointment> GetPatientAppointments(Patient patient);

        Patient DeletePatientById(int id);
    }
}
