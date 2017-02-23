using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class MultipleViewPattern : PatternBase<UIA.MultipleViewPattern>,IMultipleViewPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.Pattern.Id, "MultipleView", AutomationObjectIds.IsMultipleViewPatternAvailableProperty);
        public static readonly PropertyId CurrentViewProperty = PropertyId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.CurrentViewProperty.Id, "CurrentView");
        public static readonly PropertyId SupportedViewsProperty = PropertyId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.SupportedViewsProperty.Id, "SupportedViews");

        public MultipleViewPattern(BasicAutomationElementBase basicAutomationElement, UIA.MultipleViewPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IMultipleViewPatternProperties Properties => Automation.PropertyLibrary.MultipleView;

        public int CurrentView => Get<int>(CurrentViewProperty);

        public int[] SupportedViews => Get<int[]>(SupportedViewsProperty);

        public string GetViewName(int view)
        {
            return NativePattern.GetViewName(view);
        }

        public void SetCurrentView(int view)
        {
            NativePattern.SetCurrentView(view);
        }
    }

    public class MultipleViewPatternProperties : IMultipleViewPatternProperties
    {
        public PropertyId CurrentViewProperty => MultipleViewPattern.CurrentViewProperty;
        public PropertyId SupportedViewsProperty => MultipleViewPattern.SupportedViewsProperty;
    }
}
