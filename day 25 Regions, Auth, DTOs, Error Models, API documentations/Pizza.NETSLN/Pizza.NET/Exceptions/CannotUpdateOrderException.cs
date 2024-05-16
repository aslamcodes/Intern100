namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class CannotUpdateOrderException : Exception
    {
        public override string Message => "Cannot update order.";
    }
}