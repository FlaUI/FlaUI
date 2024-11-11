﻿using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class ProxyAssemblyNotLoadedException : FlaUIException
    {
        public ProxyAssemblyNotLoadedException()
        {
        }

        public ProxyAssemblyNotLoadedException(string message)
            : base(message)
        {
        }

        public ProxyAssemblyNotLoadedException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public ProxyAssemblyNotLoadedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if (!NET8_0_OR_GREATER)
        protected ProxyAssemblyNotLoadedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
