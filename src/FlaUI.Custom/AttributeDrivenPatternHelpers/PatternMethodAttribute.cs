using System;

namespace ManagedUiaCustomizationCore
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PatternMethodAttribute : Attribute
    {
        /// <summary>
        /// true if UI Automation should set the focus on the object before calling the method; otherwise false.
        /// </summary>
        public bool DoSetFocus { get; set; }
    }
}