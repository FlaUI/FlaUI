using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

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

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected FlaUIException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
