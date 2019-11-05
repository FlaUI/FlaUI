using System;
using System.Linq;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Converters
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
            var uia2Automation = (UIA2Automation)automation;
            if (nativeElements is UIA.AutomationElementCollection nativeElementsCollection)
            {
                var retArray = new AutomationElement[nativeElementsCollection.Count];
                for (var i = 0; i < nativeElementsCollection.Count; i++)
                {
                    var nativeElement = nativeElementsCollection[i];
                    var automationElement = uia2Automation.WrapNativeElement(nativeElement);
                    retArray[i] = automationElement;
                }
                return retArray;
            }
            if (nativeElements is UIA.AutomationElement[] nativeElementsArray)
            {
                return nativeElementsArray.Select(uia2Automation.WrapNativeElement).ToArray();
            }
            throw new ArgumentException("Input is neither an AutomationElementCollection nor an AutomationElement[]", nameof(nativeElements));
        }

        /// <summary>
        /// Converts a native element to a managed element.
        /// </summary>
        /// <param name="automation">The automation to use for the conversion.</param>
        /// <param name="nativeElement">The native element to convert.</param>
        /// <returns>The converted managed element.</returns>
        public static AutomationElement NativeToManaged(AutomationBase automation, object nativeElement)
        {
            var uia2Automation = (UIA2Automation)automation;
            return uia2Automation.WrapNativeElement((UIA.AutomationElement)nativeElement);
        }

        /// <summary>
        /// Converts a managed element to a native element.
        /// </summary>
        /// <param name="automationElement">The managed element to convert.</param>
        /// <returns>The converted native element.</returns>
        public static UIA.AutomationElement ToNative(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            if (automationElement.FrameworkAutomationElement is UIA2FrameworkAutomationElement frameworkElement)
            {
                return frameworkElement.NativeElement;
            }
            throw new Exception("Element is not an UI2 element");
        }
    }
}
