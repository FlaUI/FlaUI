using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class DockPattern : PatternBaseWithInformation<UIA.DockPattern, DockPatternInformation>, IDockPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.DockPattern.Pattern.Id, "Dock");
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(AutomationType.UIA2, UIA.DockPattern.DockPositionProperty.Id, "DockPosition");

        public DockPattern(BasicAutomationElementBase basicAutomationElement, UIA.DockPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IDockPatternInformation IPatternWithInformation<IDockPatternInformation>.Cached => Cached;

        IDockPatternInformation IPatternWithInformation<IDockPatternInformation>.Current => Current;

        public IDockPatternProperties Properties => Automation.PropertyLibrary.Dock;

        protected override DockPatternInformation CreateInformation(bool cached)
        {
            return new DockPatternInformation(BasicAutomationElement, cached);
        }

        public void SetDockPosition(DockPosition dockPos)
        {
            NativePattern.SetDockPosition((UIA.DockPosition)dockPos);
        }
    }

    public class DockPatternInformation : InformationBase, IDockPatternInformation
    {
        public DockPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public DockPosition DockPosition => Get<DockPosition>(DockPattern.DockPositionProperty);
    }

    public class DockPatternProperties : IDockPatternProperties
    {
        public PropertyId DockPositionProperty => DockPattern.DockPositionProperty;
    }
}
