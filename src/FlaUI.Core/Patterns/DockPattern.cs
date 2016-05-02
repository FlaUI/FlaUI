using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class DockPattern : PatternBase<IUIAutomationDockPattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_DockPatternId, "Dock");
        public static readonly AutomationProperty DockPositionProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DockDockPositionPropertyId, "DockPosition");

        public DockPatternInformation Cached { get; private set; }

        public DockPatternInformation Current { get; private set; }

        internal DockPattern(AutomationElement automationElement, IUIAutomationDockPattern nativePattern)
            : base(automationElement, nativePattern)
        {
            Cached = new DockPatternInformation(AutomationElement, true);
            Current = new DockPatternInformation(AutomationElement, false);
        }

        public void SetDockPosition(Definitions.DockPosition dockPos)
        {
            NativePattern.SetDockPosition((DockPosition)dockPos);
        }

        public class DockPatternInformation : InformationBase
        {
            public DockPatternInformation(AutomationElement automationElement, bool cached)
                : base(automationElement, cached)
            {
            }

            public Definitions.DockPosition DockPosition
            {
                get { return AutomationElement.SafeGetPropertyValue<Definitions.DockPosition>(DockPositionProperty, Cached); }
            }
        }
    }
}
