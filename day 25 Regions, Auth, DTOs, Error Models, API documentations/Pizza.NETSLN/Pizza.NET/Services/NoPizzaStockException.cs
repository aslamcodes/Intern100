using System.Runtime.Serialization;

namespace Pizza.NET.Services
{
    [Serializable]
    internal class NoPizzaStockException : Exception
    {
        public NoPizzaStockException()
        {
        }

        public NoPizzaStockException(string? message) : base(message)
        {
        }

        public NoPizzaStockException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoPizzaStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}