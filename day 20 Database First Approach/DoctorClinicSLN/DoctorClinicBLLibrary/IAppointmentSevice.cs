using DoctorClinicDALLibrary.Models;

namespace DoctorClinicBLLibrary
{
    public interface IAppointmentService
    {
        Appointment CreateAppointment(Appointment appointment);

        Appointment ChangeAppointmentDate(int id, DateTime newDate);

        Appointment GetAppointmentById(int id);

        Appointment DeleteAppointment(int id);

        List<Appointment> GetAllAppointments();

    }
}
