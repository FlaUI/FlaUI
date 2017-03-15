using System;

namespace ManagedUiaCustomizationCore
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PatternPropertyAttribute : Attribute
    {
        public PatternPropertyAttribute(string guid)
        {
            Guid = new Guid(guid);
        }

        public Guid Guid { get; private set; }
    }
}