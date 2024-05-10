using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace PatientBLTest
{
    public class ChangePatientNameTests
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
        public void TestPatientNameChangePass()
        {
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);

            patientRepo.Add(patient);

            var changedPatient = PatientService.ChangePatientName(patient.Id, "D2");

            Assert.That(changedPatient.Name, Is.EqualTo("D2"));
        }

        [Test]
        public void TestPatientNameChangeException()
        {

            var exception = Assert.Throws<NotFoundException>(() => PatientService.ChangePatientName(1, "D2"));

            Assert.That(exception.Message, Is.EqualTo("Patient not found"));
        }
    }
}