using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToUpdatePizzaStockException : Exception
    {
        public FailedToUpdatePizzaStockException()
        {
        }

        public FailedToUpdatePizzaStockException(string? message) : base(message)
        {
        }

        public FailedToUpdatePizzaStockException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToUpdatePizzaStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}