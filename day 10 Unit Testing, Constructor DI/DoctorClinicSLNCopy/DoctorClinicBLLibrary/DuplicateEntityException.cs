namespace DoctorClinicBLLibrary
{
    [Serializable]
    internal class DuplicateEntityException : Exception
    {

        private readonly string message;
        public DuplicateEntityException(string entity)
        {
            message = $"{entity} already exists";
        }

        public override string Message => message;

    }
}