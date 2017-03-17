using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

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

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ElementNotAvailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
