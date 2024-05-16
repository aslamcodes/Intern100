namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToDeleteOrderException : Exception
    {
        public override string Message => "Failed to Delete Order from Repository";
    }
}