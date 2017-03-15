using System;

namespace ManagedUiaCustomizationCore
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class PatternGuidAttribute : Attribute
    {
        /// <param name="patternGuid">Pattern would be registered in UIA under this GUID. Do not confuse with GUID of the pattern's client interface,
        /// which is how COM would identify. Both should be applied to the client interface and should be different</param>
        public PatternGuidAttribute(string patternGuid)
        {
            Value = new Guid(patternGuid);
        }

        public Guid Value { get; private set; }
    }
}