namespace DoctorClinicBLLibrary
{

    public class AppointmentNotFoundException : Exception
    {
        readonly private string _message;
        public AppointmentNotFoundException()
        {
            _message = "Appointment Not found Exception";
        }
        public override string Message => _message;
    }
}