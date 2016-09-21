using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TogglePattern : PatternBaseWithInformation<TogglePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TogglePatternId, "Drag");
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        internal TogglePattern(Element automationElement, UIA.IUIAutomationTogglePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TogglePatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationTogglePattern NativePattern
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
        public TogglePatternInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public ToggleState ToggleState
        {
            get { return Get<ToggleState>(TogglePattern.ToggleStateProperty); }
        }
    }
}
