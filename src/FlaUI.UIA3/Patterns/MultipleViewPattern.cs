using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class MultipleViewPattern : PatternBaseWithInformation<MultipleViewPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_MultipleViewPatternId, "MultipleView");
        public static readonly PropertyId CurrentViewProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_MultipleViewCurrentViewPropertyId, "CurrentView");
        public static readonly PropertyId SupportedViewsProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_MultipleViewSupportedViewsPropertyId, "SupportedViews");

        internal MultipleViewPattern(Element automationElement, UIA.IUIAutomationMultipleViewPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new MultipleViewPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationMultipleViewPattern NativePattern
        {
            get { return (UIA.IUIAutomationMultipleViewPattern)base.NativePattern; }
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
        public MultipleViewPatternInformation(Element automationElement, bool cached)
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
