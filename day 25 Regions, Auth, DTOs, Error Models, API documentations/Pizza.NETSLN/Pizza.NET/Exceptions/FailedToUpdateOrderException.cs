using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToUpdateOrderException : Exception
    {
        public FailedToUpdateOrderException()
        {
        }

        public FailedToUpdateOrderException(string? message) : base(message)
        {
        }

        public FailedToUpdateOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToUpdateOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}