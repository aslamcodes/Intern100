using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace AppointmentBLTests
{
    public class CreateAppointmentTests
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
        public void TestAppointmentCreation()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment = new(doctor, patient, DateTime.Now);

            var createdAppointment = appointmentService.CreateAppointment(appointment);

            Assert.That(createdAppointment.Id, Is.EqualTo(1));

        }

        [Test]
        public void TestAppointmentCreationFailure()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment = new(doctor, patient, DateTime.Now);

            Assert.Throws<DuplicateAppointmentException>(() =>
            {
                appointmentService.CreateAppointment(appointment);
                appointmentService.CreateAppointment(appointment);
            });

        }

    }
}