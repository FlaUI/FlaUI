﻿using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class NoClickablePointException : FlaUIException
    {
        public NoClickablePointException()
        {
        }

        public NoClickablePointException(string message)
            : base(message)
        {
        }

        public NoClickablePointException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public NoClickablePointException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if (!NET8_0_OR_GREATER)
        protected NoClickablePointException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
