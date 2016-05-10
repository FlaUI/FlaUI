using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class PropertyNotSupportedException : Exception
    {
        public PropertyId Property { get; private set; }

        public PropertyNotSupportedException()
        {
        }

        public PropertyNotSupportedException(string message)
            : base(message)
        {
        }

        public PropertyNotSupportedException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public PropertyNotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public PropertyNotSupportedException(string message, PropertyId property)
            : base(message)
        {
            Property = property;
        }

        public PropertyNotSupportedException(string message, PropertyId property, Exception innerException)
            : base(message, innerException)
        {
            Property = property;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected PropertyNotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Property = (PropertyId)info.GetValue("Property", typeof(PropertyId));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Property", Property);
            base.GetObjectData(info, context);
        }
    }
}
