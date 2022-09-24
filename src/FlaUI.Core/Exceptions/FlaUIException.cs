using System;
using System.Runtime.Serialization;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class FlaUIException : Exception
    {
        public FlaUIException()
        {
        }

        public FlaUIException(string message)
            : base(message)
        {
        }

        public FlaUIException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public FlaUIException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected FlaUIException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
