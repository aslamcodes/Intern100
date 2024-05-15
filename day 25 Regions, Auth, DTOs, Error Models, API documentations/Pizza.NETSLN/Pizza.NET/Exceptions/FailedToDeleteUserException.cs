using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class FailedToDeleteUserException : Exception
    {
        public FailedToDeleteUserException()
        {
        }

        public FailedToDeleteUserException(string? message) : base(message)
        {
        }

        public FailedToDeleteUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToDeleteUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}