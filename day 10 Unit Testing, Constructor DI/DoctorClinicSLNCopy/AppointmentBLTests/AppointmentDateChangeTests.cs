using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace AppointmentBLTests
{
    public class AppointmentDateChangeTests
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
        public void TestAppointmentDateChange()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment = new(doctor, patient, DateTime.Now);
            appointmentRepo.Add(appointment);

            var newDate = new DateTime(2003, 12, 1);

            var updatedAppointment = appointmentService.ChangeAppointmentDate(1, newDate);

            Assert.That(appointment.Date, Is.EqualTo(updatedAppointment.Date));
        }

        [Test]
        public void TestAppointmentDateChangeException()
        {
            var newDate = new DateTime(2003, 12, 1);

            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentService.ChangeAppointmentDate(1, newDate));

            Assert.That(exception.Message, Is.EqualTo("Appointment Not found Exception"));
        }

    }
}