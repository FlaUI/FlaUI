using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class MultipleViewPattern : PatternBaseWithInformation<UIA.IUIAutomationMultipleViewPattern, MultipleViewPatternInformation>, IMultipleViewPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_MultipleViewPatternId, "MultipleView", AutomationObjectIds.IsMultipleViewPatternAvailableProperty);
        public static readonly PropertyId CurrentViewProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_MultipleViewCurrentViewPropertyId, "CurrentView");
        public static readonly PropertyId SupportedViewsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_MultipleViewSupportedViewsPropertyId, "SupportedViews");

        public MultipleViewPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationMultipleViewPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IMultipleViewPatternInformation IPatternWithInformation<IMultipleViewPatternInformation>.Cached => Cached;

        IMultipleViewPatternInformation IPatternWithInformation<IMultipleViewPatternInformation>.Current => Current;

        public IMultipleViewPatternProperties Properties => Automation.PropertyLibrary.MultipleView;

        protected override MultipleViewPatternInformation CreateInformation(bool cached)
        {
            return new MultipleViewPatternInformation(BasicAutomationElement, cached);
        }

        public string GetViewName(int view)
        {
            return ComCallWrapper.Call(() => NativePattern.GetViewName(view));
        }

        public void SetCurrentView(int view)
        {
            ComCallWrapper.Call(() => NativePattern.SetCurrentView(view));
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
