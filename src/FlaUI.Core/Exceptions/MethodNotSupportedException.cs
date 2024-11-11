using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class MethodNotSupportedException : FlaUIException
    {
        public MethodNotSupportedException()
        {
        }

        public MethodNotSupportedException(string message)
            : base(message)
        {
        }

        public MethodNotSupportedException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public MethodNotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if (!NET8_0_OR_GREATER)
        protected MethodNotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
