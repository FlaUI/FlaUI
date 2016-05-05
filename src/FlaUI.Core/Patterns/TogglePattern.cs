using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TogglePattern : PatternBaseWithInformation<IUIAutomationTogglePattern, TogglePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TogglePatternId, "Drag");
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        internal TogglePattern(AutomationElement automationElement, IUIAutomationTogglePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TogglePatternInformation(element, cached))
        {
        }

        public void Toggle()
        {
            ComCallWrapper.Call(() => NativePattern.Toggle());
        }
    }

    public class TogglePatternInformation : InformationBase
    {
        public TogglePatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public Definitions.ToggleState ToggleState
        {
            get { return Get<Definitions.ToggleState>(TogglePattern.ToggleStateProperty); }
        }
    }
}
