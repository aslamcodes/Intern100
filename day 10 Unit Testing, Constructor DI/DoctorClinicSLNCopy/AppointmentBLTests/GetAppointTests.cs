using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace AppointmentBLTests
{
    public class GetAppointTests
    {
        private IRepository<int, Appointment> appointmentRepo;
        private IAppointmentService appointmentService;
        [SetUp]
        public void Setup()
        {
            appointmentRepo = new AppointmentRepository();

            appointmentService = new AppointmentBL(appointmentRepo);


        }

        [Test]
        public void TestGetAppointment()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment = new(doctor, patient, DateTime.Now);

            appointmentService.CreateAppointment(appointment);

            var appointments = appointmentService.GetAppointmentById(1);

            Assert.That(appointments.Id, Is.EqualTo(1));
        }

        [Test]
        public void TestGetAppointmentFailure()
        {
            Assert.Throws<AppointmentNotFoundException>(() => appointmentService.GetAppointmentById(1));
        }

    }
}