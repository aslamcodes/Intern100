namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToDeletePizzaException : Exception
    {
        public override string Message => "Couldn't Delete Pizza";

    }
}