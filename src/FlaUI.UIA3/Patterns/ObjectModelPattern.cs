using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ObjectModelPattern : PatternBase<UIA.IUIAutomationObjectModelPattern>, IObjectModelPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ObjectModelPatternId, "ObjectModel", AutomationObjectIds.IsObjectModelPatternAvailableProperty);

        public ObjectModelPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationObjectModelPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public object GetUnderlyingObjectModel()
        {
            return ComCallWrapper.Call(() => NativePattern.GetUnderlyingObjectModel());
        }
    }
}
