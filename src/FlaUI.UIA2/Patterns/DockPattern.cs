using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class DockPattern : DockPatternBase<UIA.DockPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.DockPattern.Pattern.Id, "Dock", AutomationObjectIds.IsDockPatternAvailableProperty);
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(AutomationType.UIA2, UIA.DockPattern.DockPositionProperty.Id, "DockPosition");

        public DockPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.DockPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void SetDockPosition(DockPosition dockPos)
        {
            NativePattern.SetDockPosition((UIA.DockPosition)dockPos);
        }
    }

    public class DockPatternPropertyIds : IDockPatternPropertyIds
    {
        public PropertyId DockPosition => DockPattern.DockPositionProperty;
    }
}
