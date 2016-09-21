using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ObjectModelPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_ObjectModelPatternId, "ObjectModel");

        public ObjectModelPattern(AutomationElement automationElement, UIA.IUIAutomationObjectModelPattern nativePattern)
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
