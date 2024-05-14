namespace RequestTrackerCFRelations.Exceptions
{
    public class AuthException(string message) : Exception
    {
        private readonly string _message = message;

        public override string Message => message;
    }
}
