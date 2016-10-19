using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class MultipleViewPattern : PatternBaseWithInformation<UIA.MultipleViewPattern, MultipleViewPatternInformation>,IMultipleViewPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.Pattern.Id, "MultipleView");
        public static readonly PropertyId CurrentViewProperty = PropertyId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.CurrentViewProperty.Id, "CurrentView");
        public static readonly PropertyId SupportedViewsProperty = PropertyId.Register(AutomationType.UIA2, UIA.MultipleViewPattern.SupportedViewsProperty.Id, "SupportedViews");

        public MultipleViewPattern(BasicAutomationElementBase basicAutomationElement, UIA.MultipleViewPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new MultipleViewPatternProperties();
        }

        IMultipleViewPatternInformation IPatternWithInformation<IMultipleViewPatternInformation>.Cached => Cached;

        IMultipleViewPatternInformation IPatternWithInformation<IMultipleViewPatternInformation>.Current => Current;

        public IMultipleViewPatternProperties Properties { get; }

        protected override MultipleViewPatternInformation CreateInformation(bool cached)
        {
            return new MultipleViewPatternInformation(BasicAutomationElement, cached);
        }

        public string GetViewName(int view)
        {
            return NativePattern.GetViewName(view);
        }

        public void SetCurrentView(int view)
        {
            NativePattern.SetCurrentView(view);
        }
    }

    public class MultipleViewPatternInformation : InformationBase, IMultipleViewPatternInformation
    {
        public MultipleViewPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public int CurrentView => Get<int>(MultipleViewPattern.CurrentViewProperty);

        public int[] SupportedViews => Get<int[]>(MultipleViewPattern.SupportedViewsProperty);
    }

    public class MultipleViewPatternProperties : IMultipleViewPatternProperties
    {
        public PropertyId CurrentViewProperty => MultipleViewPattern.CurrentViewProperty;
        public PropertyId SupportedViewsProperty => MultipleViewPattern.SupportedViewsProperty;
    }
}
