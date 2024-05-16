namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToDeleteUserException : Exception
    {
        public override string Message => "Failed to delete user.";
    }
}