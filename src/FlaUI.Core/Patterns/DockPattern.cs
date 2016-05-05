using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

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

        public void SetDockPosition(Definitions.DockPosition dockPos)
        {
            ComCallWrapper.Call(() => NativePattern.SetDockPosition((DockPosition)dockPos));
        }
    }

    public class DockPatternInformation : InformationBase
    {
        public DockPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public Definitions.DockPosition DockPosition
        {
            get { return Get<Definitions.DockPosition>(DockPattern.DockPositionProperty); }
        }
    }
}
