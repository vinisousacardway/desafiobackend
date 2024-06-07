using System.Runtime.Serialization;

namespace desafiobackend.Domain.Services.Interfaces
{
    [Serializable]
    internal class ImplementedException : Exception
    {
        public ImplementedException()
        {
        }

        public ImplementedException(string? message) : base(message)
        {
        }

        public ImplementedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}