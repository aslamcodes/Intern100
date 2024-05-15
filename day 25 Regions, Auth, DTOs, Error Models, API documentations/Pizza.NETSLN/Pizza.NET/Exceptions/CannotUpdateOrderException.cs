using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class CannotUpdateOrderException : Exception
    {
        public CannotUpdateOrderException()
        {
        }

        public CannotUpdateOrderException(string? message) : base(message)
        {
        }

        public CannotUpdateOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CannotUpdateOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}