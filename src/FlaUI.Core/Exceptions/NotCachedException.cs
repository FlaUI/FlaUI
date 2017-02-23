using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class NotCachedException : Exception
    {
        public NotCachedException()
        {
        }

        public NotCachedException(string message) : base(message)
        {
        }

        public NotCachedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotCachedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
