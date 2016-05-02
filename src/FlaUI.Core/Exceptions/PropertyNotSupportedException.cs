using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class PropertyNotSupportedException : Exception
    {
        public AutomationProperty Property { get; private set; }

        public PropertyNotSupportedException()
        {
        }

        public PropertyNotSupportedException(string message)
            : base(message)
        {
        }

        public PropertyNotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public PropertyNotSupportedException(string message, AutomationProperty property)
            : base(message)
        {
            Property = property;
        }

        public PropertyNotSupportedException(string message, AutomationProperty property, Exception innerException)
            : base(message, innerException)
        {
            Property = property;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected PropertyNotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Property = (AutomationProperty)info.GetValue("AutomationProperty", typeof(AutomationProperty));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("AutomationProperty", Property);
            base.GetObjectData(info, context);
        }
    }
}
