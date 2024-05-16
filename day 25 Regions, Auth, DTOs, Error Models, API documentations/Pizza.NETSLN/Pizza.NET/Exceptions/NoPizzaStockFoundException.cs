namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class NoPizzaStockFoundException : Exception
    {
        public override string Message => "No pizza stock found.";
    }
}