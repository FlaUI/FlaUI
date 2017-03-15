using System;
using System.Runtime.Serialization;

namespace ManagedUiaCustomizationCore
{
    [Serializable]
    public class UiaCallFailedException : Exception
    {
        public UiaCallFailedException()
        {
        }

        public UiaCallFailedException(string message) : base(message)
        {
        }

        public UiaCallFailedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UiaCallFailedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}