using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TogglePattern : PatternBaseWithInformation<UIA.IUIAutomationTogglePattern, TogglePatternInformation>, ITogglePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TogglePatternId, "Toggle");
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        public TogglePattern(AutomationObjectBase automationObject, UIA.IUIAutomationTogglePattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new TogglePatternProperties();
        }

        ITogglePatternInformation IPatternWithInformation<ITogglePatternInformation>.Cached
        {
            get { return Cached; }
        }

        public ITogglePatternProperties Properties { get; private set; }

        ITogglePatternInformation IPatternWithInformation<ITogglePatternInformation>.Current
        {
            get { return Current; }
        }

        protected override TogglePatternInformation CreateInformation(bool cached)
        {
            return new TogglePatternInformation(AutomationObject, cached);
        }

        public void Toggle()
        {
            ComCallWrapper.Call(() => NativePattern.Toggle());
        }
    }

    public class TogglePatternInformation : ElementInformationBase, ITogglePatternInformation
    {
        public TogglePatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public ToggleState ToggleState
        {
            get { return Get<ToggleState>(TogglePattern.ToggleStateProperty); }
        }
    }

    public class TogglePatternProperties : ITogglePatternProperties
    {
        public PropertyId ToggleStateProperty
        {
            get { return TogglePattern.ToggleStateProperty; }
        }
    }
}
