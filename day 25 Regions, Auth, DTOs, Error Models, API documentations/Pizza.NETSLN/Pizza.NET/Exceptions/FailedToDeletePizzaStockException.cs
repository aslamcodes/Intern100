namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToDeletePizzaStockException : Exception
    {
        public override string Message => "Failed to delete pizza stock.";
    }
}