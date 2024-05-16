namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class UnauthorizedUserException : Exception
    {
        public override string Message => "Unauthorized user.";
    }
}