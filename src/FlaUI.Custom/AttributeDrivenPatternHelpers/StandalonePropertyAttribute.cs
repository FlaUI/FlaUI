using System;

namespace ManagedUiaCustomizationCore
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StandalonePropertyAttribute : Attribute
    {
        public Guid Guid { get; private set; }
        public Type Type { get; private set; }

        public StandalonePropertyAttribute(string guid, Type type)
        {
            Type = type;
            Guid = new Guid(guid);
        }
    }
}