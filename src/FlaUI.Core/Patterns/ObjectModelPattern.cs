using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ObjectModelPattern : PatternBase<IUIAutomationObjectModelPattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_ObjectModelPatternId, "ObjectModel");

        public ObjectModelPattern(AutomationElement automationElement, IUIAutomationObjectModelPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public object GetUnderlyingObjectModel()
        {
            return ComCallWrapper.Call(() => NativePattern.GetUnderlyingObjectModel());
        }
    }
}
