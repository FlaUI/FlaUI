using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class DockPattern : PatternBase<UIA.DockPattern>, IDockPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.DockPattern.Pattern.Id, "Dock", AutomationObjectIds.IsDockPatternAvailableProperty);
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(AutomationType.UIA2, UIA.DockPattern.DockPositionProperty.Id, "DockPosition");

        public DockPattern(BasicAutomationElementBase basicAutomationElement, UIA.DockPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IDockPatternProperties Properties => Automation.PropertyLibrary.Dock;

        public DockPosition DockPosition => Get<DockPosition>(DockPositionProperty);

        public void SetDockPosition(DockPosition dockPos)
        {
            NativePattern.SetDockPosition((UIA.DockPosition)dockPos);
        }
    }

    public class DockPatternProperties : IDockPatternProperties
    {
        public PropertyId DockPositionProperty => DockPattern.DockPositionProperty;
    }
}
