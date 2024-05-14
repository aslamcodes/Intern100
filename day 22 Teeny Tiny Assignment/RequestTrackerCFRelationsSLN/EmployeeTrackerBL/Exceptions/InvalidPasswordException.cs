namespace EmployeeTrackerBL
{
    [Serializable]
    public class InvalidPasswordException : Exception
    {
        private readonly string _message;
        public InvalidPasswordException()
        {
            _message = $"The password provided is invalid, please try again";
        }

        override public string Message => _message;

    }
}