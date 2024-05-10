using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicDALLibrary.Models;

namespace DoctorBLTest
{
    public class DeleteDoctorTests
    {
        private IRepository<int, Doctor> DoctorRepo;
        private IRepository<int, Appointment> AppointmentRepo;
        private IDoctorService doctorService;
        [SetUp]
        public void Setup()
        {
            DoctorRepo = new DoctorRepository();
            doctorService = new DoctorBL(DoctorRepo, AppointmentRepo);


            Doctor doctor = new Doctor();
            doctor.Qualification = "MBBS";
            doctor.Speciality = "Cardiology";
            doctor.Name = "D1";

            doctorService.CreateDoctor(doctor);
        }

        [Test]
        public void TestDoctorDeletionSuccess()
        {
            var doctor = doctorService.DeleteDoctorByID(1);

            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorService.GetDoctorById(1));

            Assert.Multiple(() =>
            {
                Assert.That(doctor.Id, Is.EqualTo(1));
                Assert.That(exception.Message, Is.EqualTo("Doctor Not found"));
            });
        }

        [Test]
        public void TestDoctorRetrivalFailure()
        {
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorService.DeleteDoctorByID(2));

            Assert.That(exception.Message, Is.EqualTo("Doctor Not found"));
        }



    }
}