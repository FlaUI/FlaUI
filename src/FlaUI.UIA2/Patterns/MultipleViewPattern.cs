using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class MultipleViewPattern : MultipleViewPatternBase<UIA.MultipleViewPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.Pattern.Id, "MultipleView", AutomationObjectIds.IsMultipleViewPatternAvailableProperty);
        public static readonly PropertyId CurrentViewProperty = PropertyId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.CurrentViewProperty.Id, "CurrentView");
        public static readonly PropertyId SupportedViewsProperty = PropertyId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.SupportedViewsProperty.Id, "SupportedViews");

        public MultipleViewPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.MultipleViewPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override string GetViewName(int view)
        {
            return NativePattern.GetViewName(view);
        }

        public override void SetCurrentView(int view)
        {
            NativePattern.SetCurrentView(view);
        }
    }

    public class MultipleViewPatternProperties : IMultipleViewPatternProperties
    {
        public PropertyId CurrentView => MultipleViewPattern.CurrentViewProperty;
        public PropertyId SupportedViews => MultipleViewPattern.SupportedViewsProperty;
    }
}
