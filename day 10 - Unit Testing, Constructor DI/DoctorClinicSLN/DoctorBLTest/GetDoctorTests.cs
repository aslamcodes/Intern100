using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace DoctorBLTest
{
    public class GetDoctorTests
    {
        private IRepository<int, Doctor> DoctorRepo;
        private IRepository<int, Appointment> AppointmentRepo;
        private IDoctorService DoctorService;
        [SetUp]
        public void Setup()
        {
            DoctorRepo = new DoctorRepository();
            AppointmentRepo = new AppointmentRepository();
            DoctorService = new DoctorBL(DoctorRepo, AppointmentRepo);

            Doctor doctor = new("D1", "MBBS", "Cardiology");
            DoctorService.CreateDoctor(doctor);
        }

        [Test]
        public void TestDoctorRetrivalSuccess()
        {
            var doctor = DoctorService.GetDoctorById(1);

            Assert.That(doctor.Id, Is.EqualTo(1));
        }

        [Test]
        public void TestDoctorRetrivalFailure()
        {
            var exception = Assert.Throws<DoctorNotFoundException>(() => DoctorService.GetDoctorById(2));

            Assert.That(exception.Message, Is.EqualTo("Doctor Not found"));
        }



    }
}