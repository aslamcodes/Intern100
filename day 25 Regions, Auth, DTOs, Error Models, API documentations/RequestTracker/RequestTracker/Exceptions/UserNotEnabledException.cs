namespace RequestTracker.Exceptions
{
    [Serializable]
    internal class UserNotEnabledException : Exception
    {
        private readonly string message;
        public UserNotEnabledException(int userId)
        {
            message = $"User with id {userId} is not enabled";
        }


        public override string Message => base.Message;

    }


}