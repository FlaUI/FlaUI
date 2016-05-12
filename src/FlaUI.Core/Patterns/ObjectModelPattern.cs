using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ObjectModelPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_ObjectModelPatternId, "ObjectModel");

        public ObjectModelPattern(AutomationElement automationElement, IUIAutomationObjectModelPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public IUIAutomationObjectModelPattern NativePattern
        {
            get { return (IUIAutomationObjectModelPattern)base.NativePattern; }
        }

        public object GetUnderlyingObjectModel()
        {
            return ComCallWrapper.Call(() => NativePattern.GetUnderlyingObjectModel());
        }
    }
}
