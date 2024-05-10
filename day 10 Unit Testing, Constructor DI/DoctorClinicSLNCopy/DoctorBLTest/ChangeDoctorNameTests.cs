using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace DoctorBLTest
{
    public class ChangeDoctorNameTests
    {
        private IRepository<int, Doctor> DoctorRepo;
        private IRepository<int, Appointment> AppointmentRepo;
        private IDoctorService doctorService;
        [SetUp]
        public void Setup()
        {
            DoctorRepo = new DoctorRepository();

            doctorService = new DoctorBL(DoctorRepo, AppointmentRepo);

        }

        [Test]
        public void TestDoctorNameChangePass()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");
            DoctorRepo.Add(doctor);

            var changedDoctor = doctorService.ChangeDoctorName(doctor.Id, "D2");

            Assert.That(changedDoctor.Name, Is.EqualTo("D2"));
        }

        [Test]
        public void TestDoctorNameChangeException()
        {

            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorService.ChangeDoctorName(1, "D2"));

            Assert.That(exception.Message, Is.EqualTo("Doctor Not found"));
        }


    }
}