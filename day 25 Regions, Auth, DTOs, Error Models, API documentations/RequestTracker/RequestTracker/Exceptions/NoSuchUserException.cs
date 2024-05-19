namespace RequestTracker.Exceptions
{
    [Serializable]
    internal class NoSuchUserException : Exception
    {
        private readonly string message;
        public NoSuchUserException(int id)
        {
            message = "No user with id " + Convert.ToString(id) + " found";
        }

        public override string Message => message;
    }
}