using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class CannotDeleteOrderException : Exception
    {
        public CannotDeleteOrderException()
        {
        }

        public CannotDeleteOrderException(string? message) : base(message)
        {
        }

        public CannotDeleteOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CannotDeleteOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}