namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class NoPizzaFoundException : Exception
    {
        private readonly string message;


        public NoPizzaFoundException(int key)
        {
            message = $"No pizza found with key {key}";
        }

        public override string Message => message;
    }
}