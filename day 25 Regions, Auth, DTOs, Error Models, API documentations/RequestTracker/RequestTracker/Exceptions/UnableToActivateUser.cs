namespace RequestTracker.Exceptions
{
    [Serializable]
    internal class UnableToActivateUser : Exception
    {
        public UnableToActivateUser(string? message) : base(message)
        {
        }

        public override string Message => "Unable to activate user";
    }
}