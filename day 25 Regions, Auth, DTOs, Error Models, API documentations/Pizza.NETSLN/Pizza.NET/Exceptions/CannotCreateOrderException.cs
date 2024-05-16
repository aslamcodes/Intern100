namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class CannotCreateOrderException : Exception
    {
        public override string Message => "Cannot create order.";
    }
}