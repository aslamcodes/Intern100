namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToUpdatePizzaStockException : Exception
    {
        public override string Message => "Couldn't Update Pizza Stock";
    }
}