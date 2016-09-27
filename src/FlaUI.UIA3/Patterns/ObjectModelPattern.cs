using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ObjectModelPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ObjectModelPatternId, "ObjectModel");

        public ObjectModelPattern(Element automationElement, UIA.IUIAutomationObjectModelPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationObjectModelPattern NativePattern
        {
            get { return (UIA.IUIAutomationObjectModelPattern)base.NativePattern; }
        }

        public object GetUnderlyingObjectModel()
        {
            return ComCallWrapper.Call(() => NativePattern.GetUnderlyingObjectModel());
        }
    }
}
