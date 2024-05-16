namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToAddPizzaStockException : Exception
    {
        public override string Message => "Failed to Add Pizza Stock to Repository";
    }
}