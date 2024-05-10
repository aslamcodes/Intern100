namespace DoctorClinicBLLibrary
{

    public class DuplicateDoctorEntryException : Exception
    {
        private readonly string Msg;
        public DuplicateDoctorEntryException()
        {
            Msg = "A Duplicate Doctor Entry is present";
        }

        public override string Message => Msg;

    }
}