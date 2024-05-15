namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToAddPizzaException : Exception
    {
        public override string Message => "Failed to Add Pizza to Repository";

    }
}