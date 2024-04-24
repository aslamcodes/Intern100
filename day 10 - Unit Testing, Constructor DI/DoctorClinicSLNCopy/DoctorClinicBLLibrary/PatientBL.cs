using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace DoctorClinicBLLibrary
{
    public class PatientBL : IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;
        readonly IRepository<int, Appointment> _appointmentRepository;
        public PatientBL(IRepository<int, Patient> patientRepository, IRepository<int, Appointment> appointmentRepository)
        {
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
        }
        public Patient ChangePatientName(int patientId, string PatientNewName)
        {
            var patient = GetPatientById(patientId) ?? throw new NotFoundException("Patient");

            patient.Name = PatientNewName;

            var updatedPatient = _patientRepository.Update(patient);

            return updatedPatient ?? throw new NotFoundException("Patient");
        }

        public Patient CreatePatient(Patient patient)
        {
            var result = _patientRepository.Add(patient);

            return result ?? throw new DuplicateEntityException("Patient");
        }

        public Patient DeletePatientById(int id)
        {
            var result = _patientRepository.Delete(id);

            return result ?? throw new NotFoundException("Patient");
        }

        public List<Appointment> GetPatientAppointments(Patient patient)
        {
            List<Appointment> appointments = [];
            var allAppointments = _appointmentRepository.GetAll();

            if (allAppointments == null || allAppointments.Count == 0) throw new NoAppointmentsException();

            foreach (var appointment in allAppointments)
            {
                if (appointment.Patient.Id == patient.Id)
                {
                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        public Patient GetPatientById(int id)
        {
            var result = _patientRepository.GetByID(id);

            return result ?? throw new NotFoundException("Patient");
        }
    }
}
