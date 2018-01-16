using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3
{
    public class UIA3TextRange3 : UIA3TextRange2, ITextRange3
    {
        public UIA.IUIAutomationTextRange3 NativeRange3 { get; }

        public UIA3TextRange3(UIA3Automation automation, UIA.IUIAutomationTextRange3 nativeRange)
            : base(automation, nativeRange)
        {
            NativeRange3 = nativeRange;
        }

        public AutomationElement GetEnclosingElementBuildCache()
        {
            throw new NotImplementedException();
        }

        public AutomationElement[] GetChildrenBuildCache()
        {
            throw new NotImplementedException();
        }

        public object[] GetAttributeValues(TextAttributeId[] attributeIds)
        {
            throw new NotImplementedException();
        }
    }
}
