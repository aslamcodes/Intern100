namespace DoctorClinicBLLibrary
{

    public class NotFoundException : Exception
    {
        private readonly string message;
        public NotFoundException(string entity)
        {
            message = $"{entity} not found";
        }

        public override string Message => message;
    }
}