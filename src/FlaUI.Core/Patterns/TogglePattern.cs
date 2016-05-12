using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TogglePattern : PatternBaseWithInformation<TogglePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_TogglePatternId, "Drag");
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        internal TogglePattern(AutomationElement automationElement, UIA.IUIAutomationTogglePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TogglePatternInformation(element, cached))
        {
        }

        public UIA.IUIAutomationTogglePattern NativePattern
        {
            get { return (UIA.IUIAutomationTogglePattern)base.NativePattern; }
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

        public ToggleState ToggleState
        {
            get { return Get<ToggleState>(TogglePattern.ToggleStateProperty); }
        }
    }
}
