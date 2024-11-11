﻿using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class ElementNotAvailableException : FlaUIException
    {
        public ElementNotAvailableException()
        {
        }

        public ElementNotAvailableException(string message)
            : base(message)
        {
        }

        public ElementNotAvailableException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public ElementNotAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if (!NET8_0_OR_GREATER)
        protected ElementNotAvailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
