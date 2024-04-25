using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace PatientBLTest
{
    public class PatientDeletionTests
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

            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            patientRepo.Add(patient);
        }


        [Test]
        public void TestDoctorDeletionSuccess()
        {
            var doctor = PatientService.DeletePatientById(1);

            var exception = Assert.Throws<NotFoundException>(() => PatientService.GetPatientById(1));

            Assert.Multiple(() =>
            {
                Assert.That(doctor.Id, Is.EqualTo(1));
                Assert.That(exception.Message, Is.EqualTo("Patient not found"));
            });
        }

        [Test]
        public void TestDoctorRetrivalFailure()
        {
            var exception = Assert.Throws<NotFoundException>(() => PatientService.DeletePatientById(2));

            Assert.That(exception.Message, Is.EqualTo("Patient not found"));
        }
    }
}