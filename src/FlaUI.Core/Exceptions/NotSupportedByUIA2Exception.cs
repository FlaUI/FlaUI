using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace FlaUI.Core.Exceptions
{
    public class NotSupportedByUIA2Exception : Exception
    {
        public NotSupportedByUIA2Exception()
        {
        }

        public NotSupportedByUIA2Exception(string message)
            : base(message)
        {
        }

        public NotSupportedByUIA2Exception(Exception innerException) :
            base(String.Empty, innerException)
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
                throw new ArgumentNullException("info");
            }
            base.GetObjectData(info, context);
        }
    }
}
