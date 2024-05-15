using System.Runtime.Serialization;

namespace Pizza.NET.Exceptions
{
    [Serializable]
    internal class NoOrderFoundException : Exception
    {
        public NoOrderFoundException(int key)
        {
        }

        public NoOrderFoundException(string? message) : base(message)
        {
        }

        public NoOrderFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoOrderFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}