using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class DockPattern : PatternBaseWithInformation<DockPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_DockPatternId, "Dock");
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DockDockPositionPropertyId, "DockPosition");

        internal DockPattern(AutomationElement automationElement, UIA.IUIAutomationDockPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new DockPatternInformation(element, cached))
        {
        }

        public UIA.IUIAutomationDockPattern NativePattern
        {
            get { return (UIA.IUIAutomationDockPattern)base.NativePattern; }
        }

        public void SetDockPosition(DockPosition dockPos)
        {
            ComCallWrapper.Call(() => NativePattern.SetDockPosition((UIA.DockPosition)dockPos));
        }
    }

    public class DockPatternInformation : InformationBase
    {
        public DockPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public DockPosition DockPosition
        {
            get { return Get<DockPosition>(DockPattern.DockPositionProperty); }
        }
    }
}
