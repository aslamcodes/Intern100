using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace DoctorClinicBLLibrary
{
    public class AppointmentBL : IAppointmentService
    {
        readonly IRepository<int, Appointment> _appointmentRepository;

        public AppointmentBL(IRepository<int, Appointment> appointmentRepo)
        {
            _appointmentRepository = appointmentRepo;
        }

        public Appointment ChangeAppointmentDate(int id, DateTime newDate)
        {
            var appointment = GetAppointmentById(id);

            return appointment ?? throw new AppointmentNotFoundException();
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            var result = _appointmentRepository.Add(appointment);

            return result ?? throw new DuplicateAppointmentException();
        }

        public Appointment DeleteAppointment(int id)
        {
            var result = _appointmentRepository.Delete(id);

            if (result != null) return result;

            throw new AppointmentNotFoundException();
        }

        public List<Appointment> GetAllAppointments()
        {
            var result = _appointmentRepository.GetAll();

            return result ?? throw new NoAppointmentsException();
        }

        public Appointment GetAppointmentById(int id)
        {
            var appointment = _appointmentRepository.GetByID(id);

            return appointment ?? throw new AppointmentNotFoundException();
        }
    }
}
