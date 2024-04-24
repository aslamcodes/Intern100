using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace DoctorBLTest
{
    public class GetDoctorAppointmentsTests
    {
        private IRepository<int, Doctor> DoctorRepo;
        private IRepository<int, Appointment> AppointmentRepo;
        private IDoctorService doctorService;
        [SetUp]
        public void Setup()
        {
            DoctorRepo = new DoctorRepository();
            AppointmentRepo = new AppointmentRepository();
            doctorService = new DoctorBL(DoctorRepo, AppointmentRepo);


        }

        [Test]
        public void TestDoctorAppointmentsRetrival()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment = new(doctor, patient, DateTime.Now);

            DoctorRepo.Add(doctor);
            AppointmentRepo.Add(appointment);

            var appointments = doctorService.GetDoctorAppointments(doctor);

            Assert.That(appointments, Has.Count.EqualTo(1));
            Assert.That(appointments[0], Is.EqualTo(appointment));
        }

        [Test]
        public void TestDoctorAppointmentsRetrivalFailure()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");


            DoctorRepo.Add(doctor);



            var exception = Assert.Throws<NoAppointmentsException>(() => doctorService.GetDoctorAppointments(doctor));

            Assert.That(exception, Has.Message.EqualTo("No Appointments created"));
        }



    }
}