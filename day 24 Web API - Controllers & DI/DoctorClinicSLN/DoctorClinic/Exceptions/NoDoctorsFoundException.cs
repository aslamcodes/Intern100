namespace DoctorClinic.Exceptions
{
    [Serializable]
    public class NoDoctorsFoundException : Exception
    {
        public override string Message => "No doctors found";
    }
}