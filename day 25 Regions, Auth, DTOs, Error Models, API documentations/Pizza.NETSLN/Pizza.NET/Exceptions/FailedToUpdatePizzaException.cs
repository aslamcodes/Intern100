namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToUpdatePizzaException : Exception
    {
        public override string Message => "Couldn't Update Pizza";
    }
}