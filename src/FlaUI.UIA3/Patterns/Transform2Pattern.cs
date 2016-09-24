using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class Transform2Pattern : TransformPattern<UIA.IUIAutomationTransformPattern2, Transform2PatternInformation>, ITransform2Pattern
    {
        public Transform2Pattern(AutomationObjectBase automationObject, UIA.IUIAutomationTransformPattern2 nativePattern) : base(automationObject, nativePattern)
        {
        }

        ITransform2PatternInformation IPatternWithInformation<ITransform2PatternInformation>.Cached
        {
            get { return Cached; }
        }

        ITransform2PatternInformation IPatternWithInformation<ITransform2PatternInformation>.Current
        {
            get { return Current; }
        }

        public void Zoom(double zoom)
        {
            ComCallWrapper.Call(() => NativePattern.Zoom(zoom));
        }

        public void ZoomByUnit(ZoomUnit zoomUnit)
        {
            ComCallWrapper.Call(() => NativePattern.ZoomByUnit((UIA.ZoomUnit)zoomUnit));
        }


        protected override Transform2PatternInformation CreateInformation(bool cached)
        {
           return new Transform2PatternInformation(AutomationObject, cached);
        }
    }
}
