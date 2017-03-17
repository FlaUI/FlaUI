using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

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

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ElementNotEnabledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
