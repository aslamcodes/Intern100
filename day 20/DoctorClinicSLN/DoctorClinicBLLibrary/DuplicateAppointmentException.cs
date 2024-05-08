
namespace DoctorClinicBLLibrary
{

    public class DuplicateAppointmentException : Exception
    {
        private readonly string message;
        public DuplicateAppointmentException()
        {
            message = "Already there is a appointment";
        }

        public override string Message => message;
    }
}