using DoctorClinicModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public interface IAppointmentService
    {
        Appointment CreateAppointment(Doctor doctor, Patient patient);

        Appointment ChangeAppointmentDate(int id, DateTime newDate);

        Appointment GetAppointmentById(int id);

        Appointment DeleteAppointment(int id);

        Appointment GetAllAppointments();

    }
}
