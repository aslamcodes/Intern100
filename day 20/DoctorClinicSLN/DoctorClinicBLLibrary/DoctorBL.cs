using DoctorClinicDALLibrary;
using DoctorClinicDALLibrary.Models;


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
            var allAppointments = appointmentsRepository.GetAll();

            List<Appointment> appointments = [];

            foreach (var appointment in allAppointments)
            {
                if (appointment.Doctorid == doctor.Id)
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
