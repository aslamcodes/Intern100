using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace AppointmentBLTests
{
    public class DeleteAppointmentTests
    {
        private IRepository<int, Appointment> appointmentRepo;
        private IAppointmentService appointmentService;
        [SetUp]
        public void Setup()
        {
            appointmentRepo = new AppointmentRepository();

            appointmentService = new AppointmentBL(appointmentRepo);

            Doctor doctor = new("D1", "MBBS", "Cardiology");
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment = new(doctor, patient, DateTime.Now);

            appointmentService.CreateAppointment(appointment);
        }

        [Test]
        public void TestAppointmentDeletion()
        {
            var createdAppointment = appointmentService.DeleteAppointment(1);

            Assert.That(createdAppointment.Id, Is.EqualTo(1));
        }

        [Test]
        public void TestAppointmentDeletionFailure()
        {

            var createdAppointment = appointmentService.DeleteAppointment(1);

            Assert.Throws<AppointmentNotFoundException>(() => appointmentService.DeleteAppointment(10));
        }

    }
}