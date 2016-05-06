using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;
using DockPosition = FlaUI.Core.Definitions.DockPosition;

namespace FlaUI.Core.Patterns
{
    public class DockPattern : PatternBaseWithInformation<IUIAutomationDockPattern, DockPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_DockPatternId, "Dock");
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(UIA_PropertyIds.UIA_DockDockPositionPropertyId, "DockPosition");

        internal DockPattern(AutomationElement automationElement, IUIAutomationDockPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new DockPatternInformation(element, cached))
        {
        }

        public void SetDockPosition(DockPosition dockPos)
        {
            ComCallWrapper.Call(() => NativePattern.SetDockPosition((interop.UIAutomationCore.DockPosition)dockPos));
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
