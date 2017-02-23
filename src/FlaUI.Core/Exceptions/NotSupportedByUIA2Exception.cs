using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace FlaUI.Core.Exceptions
{
    public class NotSupportedByUIA2Exception : Exception
    {
        private const string DefaultMessage = "The requested pattern or property is not supported by UIA2. Consider using UIA3.";

        public NotSupportedByUIA2Exception() : base(DefaultMessage)
        {
        }

        public NotSupportedByUIA2Exception(string message)
            : base(message)
        {
        }

        public NotSupportedByUIA2Exception(Exception innerException) :
            base(DefaultMessage, innerException)
        {
        }

        public NotSupportedByUIA2Exception(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected NotSupportedByUIA2Exception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            base.GetObjectData(info, context);
        }
    }
}
