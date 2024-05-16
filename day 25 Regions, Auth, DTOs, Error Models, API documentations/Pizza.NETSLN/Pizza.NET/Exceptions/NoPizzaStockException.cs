namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class NoPizzaStockException : Exception
    {
        public override string Message => "No pizza stock available.";
    }
}