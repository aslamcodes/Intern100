namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToUpdateOrderException : Exception
    {
        public override string Message => "Failed to Update Order";
    }
}