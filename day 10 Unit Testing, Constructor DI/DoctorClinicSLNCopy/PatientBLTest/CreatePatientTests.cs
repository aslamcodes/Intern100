using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace PatientBLTest
{
    public class CreatePatientTests
    {
        private IRepository<int, Appointment> appointmentRepo;
        private IRepository<int, Patient> patientRepo;

        private IPatientService patientService;
        [SetUp]
        public void Setup()
        {
            appointmentRepo = new AppointmentRepository();
            patientRepo = new PatientRepository();
            patientService = new PatientBL(patientRepo, appointmentRepo);
        }


        [Test]
        public void TestPatientCreation()
        {
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            var createdPatient = patientService.CreatePatient(patient);

            Assert.That(createdPatient, Is.Not.Null);
        }
    }
}