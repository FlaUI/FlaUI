using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Converters
{
    public static class AutomationElementConverter
    {
        public static AutomationElement[] NativeArrayToManaged(AutomationBase automation, object nativeElements)
        {
            if (nativeElements == null)
            {
                return new AutomationElement[0];
            }
            var uia3Automation = (UIA3Automation)automation;
            var nativeElementsCasted = (UIA.IUIAutomationElementArray)nativeElements;
            var retArray = new AutomationElement[nativeElementsCasted.Length];
            for (var i = 0; i < nativeElementsCasted.Length; i++)
            {
                var nativeElement = nativeElementsCasted.GetElement(i);
                var automationElement = uia3Automation.WrapNativeElement(nativeElement);
                retArray[i] = automationElement;
            }
            return retArray;
        }

        public static AutomationElement NativeToManaged(AutomationBase automation, object nativeElement)
        {
            var uia3Automation = (UIA3Automation)automation;
            return uia3Automation.WrapNativeElement((UIA.IUIAutomationElement)nativeElement);
        }

        public static UIA.IUIAutomationElement ToNative(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            var frameworkElement = automationElement.FrameworkAutomationElement as UIA3FrameworkAutomationElement;
            if (frameworkElement == null)
            {
                throw new Exception("Element is not an UIA3 element");
            }
            return frameworkElement.NativeElement;
        }
    }
}
