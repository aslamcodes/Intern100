using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToAddPizzaStockException : Exception
    {
        public FailedToAddPizzaStockException()
        {
        }

        public FailedToAddPizzaStockException(string? message) : base(message)
        {
        }

        public FailedToAddPizzaStockException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToAddPizzaStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}