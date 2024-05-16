namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class CannotDeleteOrderException : Exception
    {
        public override string Message => "Cannot delete order.";
    }
}