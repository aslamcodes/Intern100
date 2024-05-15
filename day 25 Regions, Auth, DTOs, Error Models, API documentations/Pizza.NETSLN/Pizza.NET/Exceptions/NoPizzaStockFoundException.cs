using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class NoPizzaStockFoundException : Exception
    {
        public NoPizzaStockFoundException()
        {
        }

        public NoPizzaStockFoundException(string? message) : base(message)
        {
        }

        public NoPizzaStockFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoPizzaStockFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}