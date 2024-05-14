namespace DoctorClinic.Exceptions
{
    [Serializable]
    internal class DoctorNotFoundException : Exception
    {
        public override string Message => "Doctor not found";
    }
}