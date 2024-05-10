using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace PatientBLTest
{
    public class GetPatientAppointmentsTest
    {
        private IRepository<int, Appointment> appointmentRepo;
        private IRepository<int, Patient> patientRepo;

        private IPatientService PatientService;
        [SetUp]
        public void Setup()
        {
            appointmentRepo = new AppointmentRepository();
            patientRepo = new PatientRepository();
            PatientService = new PatientBL(patientRepo, appointmentRepo);
        }



        [Test]
        public void TestPatientAppointmentsRetrival()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment = new(doctor, patient, DateTime.Now);

            patientRepo.Add(patient);
            appointmentRepo.Add(appointment);

            var appointments = PatientService.GetPatientAppointments(patient);

            Assert.That(appointments, Has.Count.EqualTo(1));
            Assert.That(appointments[0], Is.EqualTo(appointment));
        }



        [Test]
        public void TestDoctorAppointmentsRetrivalFailure()
        {
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);

            patientRepo.Add(patient);

            var exception = Assert.Throws<NoAppointmentsException>(() => PatientService.GetPatientAppointments(patient));

            Assert.That(exception, Has.Message.EqualTo("No Appointments created"));
        }


    }
}