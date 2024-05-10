namespace DoctorClinicBLLibrary
{
    public class DoctorNotFoundException : Exception
    {
        readonly string msg = string.Empty;
        public DoctorNotFoundException()
        {
            msg = "Doctor Not found";
        }

        public override string Message => msg;
    }
}