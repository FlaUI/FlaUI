﻿using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    /// <summary>
    /// Base class for information objects
    /// </summary>
    public abstract class InformationBase
    {
        /// <summary>
        /// The element this information belongs to
        /// </summary>
        protected Element AutomationElement { get; private set; }

        /// <summary>
        /// Flag to indicate if the information is cached or not
        /// </summary>
        protected bool Cached { get; private set; }

        protected InformationBase(Element automationElement, bool cached)
        {
            AutomationElement = automationElement;
            Cached = cached;
        }

        /// <summary>
        /// Shortcut to get the property 
        /// </summary>
        protected T Get<T>(PropertyId property)
        {
            return AutomationElement.SafeGetPropertyValue<T>(property, Cached);
        }

        protected Element[] NativeElementArrayToElements(PropertyId property)
        {
            var nativeElements = Get<UIA.IUIAutomationElementArray>(property);
            return NativeValueConverter.NativeArrayToManaged(AutomationElement.Automation, nativeElements);
        }

        protected Element NativeElementToElement(PropertyId property)
        {
            var nativeElement = Get<UIA.IUIAutomationElement>(property);
            return NativeValueConverter.NativeToManaged(AutomationElement.Automation, nativeElement);
        }
    }
}
