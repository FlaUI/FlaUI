using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Converters
{
    /// <summary>
    /// Class that helps converting automation elements.
    /// </summary>
    public static class AutomationElementConverter
    {
        /// <summary>
        /// Converts a native array of elements to an array of managed elements.
        /// </summary>
        /// <param name="automation">The automation to use for the conversion.</param>
        /// <param name="nativeElements">The native array to convert.</param>
        /// <returns>The array of managed elements.</returns>
        public static AutomationElement[] NativeArrayToManaged(AutomationBase automation, object nativeElements)
        {
            if (nativeElements == null)
            {
                return new AutomationElement[0];
            }
            var uia3Automation = (UIA3Automation)automation;
            var nativeElementArray = (UIA.IUIAutomationElementArray)nativeElements;
            var retArray = new AutomationElement[nativeElementArray.Length];
            for (var i = 0; i < nativeElementArray.Length; i++)
            {
                var nativeElement = nativeElementArray.GetElement(i);
                var automationElement = uia3Automation.WrapNativeElement(nativeElement);
                retArray[i] = automationElement;
            }
            return retArray;
        }

        /// <summary>
        /// Converts a native element to a managed element.
        /// </summary>
        /// <param name="automation">The automation to use for the conversion.</param>
        /// <param name="nativeElement">The native element to convert.</param>
        /// <returns>The converted managed element.</returns>
        public static AutomationElement NativeToManaged(AutomationBase automation, object nativeElement)
        {
            var uia3Automation = (UIA3Automation)automation;
            return uia3Automation.WrapNativeElement((UIA.IUIAutomationElement)nativeElement);
        }

        /// <summary>
        /// Converts a managed element to a native element.
        /// </summary>
        /// <param name="automationElement">The managed element to convert.</param>
        /// <returns>The converted native element.</returns>
        public static UIA.IUIAutomationElement ToNative(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            if (automationElement.FrameworkAutomationElement is UIA3FrameworkAutomationElement frameworkElement)
            {
                return frameworkElement.NativeElement;
            }
            throw new Exception("Element is not an UIA3 element");
        }
    }
}
