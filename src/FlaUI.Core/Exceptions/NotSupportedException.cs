using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

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

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected NotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
