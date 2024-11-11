using System;
using System.Runtime.Serialization;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class PropertyNotSupportedException : NotSupportedException
    {
        private const string DefaultMessage = "The requested property is not supported";
        private const string DefaultMessageWithData = "The requested property '{0}' is not supported";

        public PropertyNotSupportedException() : base(DefaultMessage)
        {
        }

        public PropertyNotSupportedException(PropertyId property)
            : base(String.Format(DefaultMessageWithData, property))
        {
            Property = property;
        }

        public PropertyNotSupportedException(string message, PropertyId property)
            : base(message)
        {
            Property = property;
        }

        public PropertyNotSupportedException(PropertyId property, Exception innerException)
            : base(String.Format(DefaultMessageWithData, property), innerException)
        {
            Property = property;
        }

        public PropertyNotSupportedException(string message, PropertyId property, Exception innerException)
            : base(message, innerException)
        {
            Property = property;
        }

#if (!NET8_0_OR_GREATER)
        protected PropertyNotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Property = (PropertyId)info.GetValue("Property", typeof(PropertyId));
        }
#endif

        public PropertyId Property { get; }

#if (!NET8_0_OR_GREATER)
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            info.AddValue("Property", Property);
            base.GetObjectData(info, context);
        }
#endif
    }
}
