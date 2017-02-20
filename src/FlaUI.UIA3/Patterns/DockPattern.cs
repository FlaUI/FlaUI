using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class DockPattern : PatternBaseWithInformation<UIA.IUIAutomationDockPattern, DockPatternInformation>, IDockPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_DockPatternId, "Dock", AutomationObjectIds.IsDockPatternAvailableProperty);
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DockDockPositionPropertyId, "DockPosition");

        public DockPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationDockPattern nativePattern) : base(basicAutomationElement, nativePattern)
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
            ComCallWrapper.Call(() => NativePattern.SetDockPosition((UIA.DockPosition)dockPos));
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
