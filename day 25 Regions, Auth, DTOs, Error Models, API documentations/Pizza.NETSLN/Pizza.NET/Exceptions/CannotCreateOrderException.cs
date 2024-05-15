using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class CannotCreateOrderException : Exception
    {
        public CannotCreateOrderException()
        {
        }

        public CannotCreateOrderException(string? message) : base(message)
        {
        }

        public CannotCreateOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CannotCreateOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}