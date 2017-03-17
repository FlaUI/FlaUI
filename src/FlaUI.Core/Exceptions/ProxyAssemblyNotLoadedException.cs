using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class ProxyAssemblyNotLoadedException : FlaUIException
    {
        public ProxyAssemblyNotLoadedException()
        {
        }

        public ProxyAssemblyNotLoadedException(string message)
            : base(message)
        {
        }

        public ProxyAssemblyNotLoadedException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public ProxyAssemblyNotLoadedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ProxyAssemblyNotLoadedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
