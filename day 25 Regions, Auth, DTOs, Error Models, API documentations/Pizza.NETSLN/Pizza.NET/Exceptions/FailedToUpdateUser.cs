namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToUpdateUser : Exception
    {
        public override string Message => "Failed to update the user";
    }
}