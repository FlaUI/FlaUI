using System;
using System.Runtime.Serialization;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class PropertyNotCachedException : NotCachedException
    {
        private const string DefaultMessage = "The requested property is not cached";
        private const string DefaultMessageWithData = "The requested property '{0}' is not cached";

        public PropertyNotCachedException() : base(DefaultMessage)
        {
        }

        public PropertyNotCachedException(PropertyId property) : base(String.Format(DefaultMessageWithData, property))
        {
            Property = property;
        }

        public PropertyNotCachedException(string message, PropertyId property) : base(message)
        {
            Property = property;
        }

        public PropertyNotCachedException(PropertyId property, Exception innerException) : base(String.Format(DefaultMessageWithData, property), innerException)
        {
            Property = property;
        }

        public PropertyNotCachedException(string message, PropertyId property, Exception innerException) : base(message, innerException)
        {
            Property = property;
        }

        protected PropertyNotCachedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Property = (PropertyId)info.GetValue("Property", typeof(PropertyId));
        }

        public PropertyId Property { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            info.AddValue("Property", Property);
            base.GetObjectData(info, context);
        }
    }
}
