﻿using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class NotSupportedByFrameworkException : FlaUIException
    {
        private const string DefaultMessage = "The requested pattern or property is not supported by the choosen framework. Consider using a newer framework.";

        public NotSupportedByFrameworkException() : base(DefaultMessage)
        {
        }

        public NotSupportedByFrameworkException(string message)
            : base(message)
        {
        }

        public NotSupportedByFrameworkException(Exception innerException)
            : base(DefaultMessage, innerException)
        {
        }

        public NotSupportedByFrameworkException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if (!NET8_0_OR_GREATER)
        protected NotSupportedByFrameworkException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
