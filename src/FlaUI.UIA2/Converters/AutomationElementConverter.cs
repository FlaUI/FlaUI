using System;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Converters
{
    public static class AutomationElementConverter
    {
        public static AutomationElement[] NativeArrayToManaged(UIA2Automation automation, UIA.AutomationElementCollection nativeElements)
        {
            if (nativeElements == null)
            {
                return new AutomationElement[0];
            }
            var retArray = new AutomationElement[nativeElements.Count];
            for (var i = 0; i < nativeElements.Count; i++)
            {
                var nativeElement = nativeElements[i];
                var automationElement = automation.WrapNativeElement(nativeElement);
                retArray[i] = automationElement;
            }
            return retArray;
        }

        public static AutomationElement[] NativeArrayToManaged(UIA2Automation automation, UIA.AutomationElement[] nativeElements)
        {
            if (nativeElements == null)
            {
                return new AutomationElement[0];
            }
            return nativeElements.Select(automation.WrapNativeElement).ToArray();
        }

        public static AutomationElement NativeToManaged(UIA2Automation automation, UIA.AutomationElement nativeElement)
        {
            return automation.WrapNativeElement(nativeElement);
        }

        public static UIA.AutomationElement ToNative(AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            var basicElement = automationElement.BasicAutomationElement as UIA2BasicAutomationElement;
            if (basicElement == null)
            {
                throw new Exception("Element is not an UI2 element");
            }
            return basicElement.NativeElement;
        }
    }
}
