using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicDALLibrary.Models;

namespace DoctorBLTest
{
    public class CreateDoctorTests
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
        public void TestDoctorCreation()
        {

            Doctor doctor = new Doctor();
            doctor.Qualification = "MBBS";
            doctor.Speciality = "Cardiology";
            doctor.Name = "D1";

            var createdDoctor = doctorService.CreateDoctor(doctor);

            Assert.That(createdDoctor, Is.Not.Null);
            Assert.That(createdDoctor.Id, Is.EqualTo(1));

        }

        [Test]
        public void TestDoctorCreationFails()
        {

            Doctor doctor = new Doctor();
            doctor.Qualification = "MBBS";
            doctor.Speciality = "Cardiology";
            doctor.Name = "D1";

            Doctor doctor2 = new Doctor();
            doctor2.Qualification = "MBBS";
            doctor2.Speciality = "Cardiology";
            doctor2.Name = "D2";

            doctorService.CreateDoctor(doctor2);

            var exception = Assert.Throws<DuplicateDoctorEntryException>(() => doctorService.CreateDoctor(doctor));
            Assert.That(exception.Message, Is.EqualTo("A Duplicate Doctor Entry is present"));
        }


    }
}