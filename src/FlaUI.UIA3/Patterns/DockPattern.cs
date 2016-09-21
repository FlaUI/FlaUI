using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class DockPattern : PatternBaseWithInformation<DockPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_DockPatternId, "Dock");
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DockDockPositionPropertyId, "DockPosition");

        internal DockPattern(Element automationElement, UIA.IUIAutomationDockPattern nativePattern)
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
        public DockPatternInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public DockPosition DockPosition
        {
            get { return Get<DockPosition>(DockPattern.DockPositionProperty); }
        }
    }
}
