namespace RequestTracker.Exceptions
{
    [Serializable]
    internal class NoRequestFoundException : Exception
    {
        public override string Message => "No request found";
    }
}