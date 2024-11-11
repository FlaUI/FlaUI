using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class NotCachedException : FlaUIException
    {
        public NotCachedException()
        {
        }

        public NotCachedException(string message)
            : base(message)
        {
        }

        public NotCachedException(Exception innerException) :
            base(String.Empty, innerException)
        {
        }

        public NotCachedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if (!NET8_0_OR_GREATER)
        protected NotCachedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
