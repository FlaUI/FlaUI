﻿using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class NotSupportedException : FlaUIException
    {
        public NotSupportedException()
        {
        }

        public NotSupportedException(string message)
            : base(message)
        {
        }

        public NotSupportedException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public NotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if (!NET8_0_OR_GREATER)
        protected NotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
