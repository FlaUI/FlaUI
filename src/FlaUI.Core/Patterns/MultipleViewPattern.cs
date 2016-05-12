using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class MultipleViewPattern : PatternBaseWithInformation<MultipleViewPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_MultipleViewPatternId, "MultipleView");
        public static readonly PropertyId CurrentViewProperty = PropertyId.Register(UIA_PropertyIds.UIA_MultipleViewCurrentViewPropertyId, "CurrentView");
        public static readonly PropertyId SupportedViewsProperty = PropertyId.Register(UIA_PropertyIds.UIA_MultipleViewSupportedViewsPropertyId, "SupportedViews");

        internal MultipleViewPattern(AutomationElement automationElement, IUIAutomationMultipleViewPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new MultipleViewPatternInformation(element, cached))
        {
        }

        public IUIAutomationMultipleViewPattern NativePattern
        {
            get { return (IUIAutomationMultipleViewPattern)base.NativePattern; }
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

    public class MultipleViewPatternInformation : InformationBase
    {
        public MultipleViewPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public int CurrentView
        {
            get { return Get<int>(MultipleViewPattern.CurrentViewProperty); }
        }

        public int[] SupportedViews
        {
            get { return Get<int[]>(MultipleViewPattern.SupportedViewsProperty); }
        }
    }
}
