using DoctorClinicDALLibrary.Models;

namespace DoctorClinicBLLibrary
{
    public interface IPatientService
    {
        Patient CreatePatient(Patient patient);

        Patient ChangePatientName(int id, string PatientNewName);

        Patient GetPatientById(int id);

        List<Appointment> GetPatientAppointments(Patient patient);

        Patient DeletePatientById(int id);
    }
}
