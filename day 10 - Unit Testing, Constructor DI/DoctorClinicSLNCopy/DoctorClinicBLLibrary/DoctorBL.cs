using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace DoctorClinicBLLibrary
{
    public class DoctorBL(IRepository<int, Doctor> doctorRepository, IRepository<int, Appointment> appointmentsRepository) : IDoctorService
    {
        public Doctor ChangeDoctorName(int id, string DoctorNewName)
        {
            var doctor = GetDoctorById(id);

            doctor.Name = DoctorNewName;

            return doctorRepository.Update(doctor) ?? throw new DoctorNotFoundException();
        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            var newDoctor = doctorRepository.Add(doctor);

            return newDoctor ?? throw new DuplicateDoctorEntryException();
        }

        public Doctor DeleteDoctorByID(int id)
        {
            var doctor = doctorRepository.Delete(id);

            return doctor ?? throw new DoctorNotFoundException();
        }

        public List<Appointment> GetDoctorAppointments(Doctor doctor)
        {
            List<Appointment> appointments = [];
            var allAppointments = appointmentsRepository.GetAll();

            if (allAppointments == null || allAppointments.Count == 0) throw new NoAppointmentsException();

            foreach (var appointment in allAppointments)
            {
                if (appointment.AppointedDoctor.Id == doctor.Id)
                {
                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        public Doctor GetDoctorById(int id)
        {
            var doctor = doctorRepository.GetByID(id);

            return doctor ?? throw new DoctorNotFoundException();
        }
    }
}
