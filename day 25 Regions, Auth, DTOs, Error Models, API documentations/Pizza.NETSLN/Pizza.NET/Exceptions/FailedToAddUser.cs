namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToAddUser : Exception
    {
        public override string Message => "Can't add user to repository";
    }
}