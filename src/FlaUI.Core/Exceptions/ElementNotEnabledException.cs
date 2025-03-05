using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class ElementNotEnabledException : FlaUIException
    {
        public ElementNotEnabledException()
        {
        }

        public ElementNotEnabledException(string message)
            : base(message)
        {
        }

        public ElementNotEnabledException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public ElementNotEnabledException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if (!NET8_0_OR_GREATER)
        protected ElementNotEnabledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
