using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToDeletePizzaStockException : Exception
    {
        public FailedToDeletePizzaStockException()
        {
        }

        public FailedToDeletePizzaStockException(string? message) : base(message)
        {
        }

        public FailedToDeletePizzaStockException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToDeletePizzaStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}