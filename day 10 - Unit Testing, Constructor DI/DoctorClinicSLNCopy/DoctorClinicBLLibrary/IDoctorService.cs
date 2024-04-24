using DoctorClinicModelLib;

namespace DoctorClinicBLLibrary
{
    public interface IDoctorService
    {
        Doctor CreateDoctor(Doctor doctor);

        Doctor ChangeDoctorName(int doctorId, string DoctorNewName);

        Doctor GetDoctorById(int id);

        List<Appointment> GetDoctorAppointments(Doctor doctor);

        Doctor DeleteDoctorByID(int id);
    }
}
