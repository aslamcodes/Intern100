using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace PatientBLTest
{
    public class GetPatientTests
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
        public void TestPatientRetrival()
        {

            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            patientRepo.Add(patient);

            var result = patientService.GetPatientById(1);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void TestPatientRetrivalFailure()
        {
            var exception = Assert.Throws<NotFoundException>(() => patientService.GetPatientById(1));

            Assert.That(exception.Message, Is.EqualTo("Patient not found"));
        }
    }
}