using DoctorClinicBLLibrary;
using DoctorClinicDALLibrary;
using DoctorClinicModelLib;

namespace AppointmentBLTests
{
    public class GetAllAppointmentTests
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
        public void TestGetAllAppointments()
        {
            Doctor doctor = new("D1", "MBBS", "Cardiology");
            Patient patient = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment = new(doctor, patient, DateTime.Now);

            Doctor doctor1 = new("D1", "MBBS", "Cardiology");
            Patient patient1 = new("Aslam", "A1", 20, "Male", 90, 180);
            Appointment appointment1 = new(doctor1, patient1, DateTime.Now);

            appointmentService.CreateAppointment(appointment);
            appointmentService.CreateAppointment(appointment1);

            var appointments = appointmentService.GetAllAppointments();

            Assert.That(appointments, Has.Count.EqualTo(2));
        }

        [Test]
        public void TestAppointmentDeletionFailure()
        {
            Assert.Throws<NoAppointmentsException>(() => appointmentService.GetAllAppointments());
        }

    }
}