using DoctorClinicDALLibrary;
using DoctorClinicModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public class AppointmentBL : IAppointmentService
    {
        readonly IRepository<int, Appointment> _appointmentRepository;

        public AppointmentBL()
        {
            _appointmentRepository = new AppointmentRepository();
        }
        public Appointment ChangeAppointmentDate(int id, DateTime newDate)
        {
            throw new NotImplementedException();
        }

        public Appointment CreateAppointment(Doctor doctor, Patient patient)
        {
            // Create a appoint class and add it
            throw new NotImplementedException();
        }

        public Appointment DeleteAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
