using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class DockPattern : PatternBaseWithInformation<DockPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_DockPatternId, "Dock");
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DockDockPositionPropertyId, "DockPosition");

        internal DockPattern(AutomationElement automationElement, UIA.IUIAutomationDockPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new DockPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationDockPattern NativePattern
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
