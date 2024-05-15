namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class NoUserFoundException : Exception
    {
        public override string Message => "No user found in the repository";
    }
}