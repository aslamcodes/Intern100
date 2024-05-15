using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToDeleteOrderException : Exception
    {
        public FailedToDeleteOrderException()
        {
        }

        public FailedToDeleteOrderException(string? message) : base(message)
        {
        }

        public FailedToDeleteOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToDeleteOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}