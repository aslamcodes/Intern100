namespace DoctorClinicBLLibrary
{

    public class NoAppointmentsException : Exception
    {
        private readonly string Msg;
        public NoAppointmentsException()
        {

            Msg = "No Appointments created";
        }
        public override string Message => Msg;
    }
}