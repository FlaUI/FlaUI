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
            Properties = new Transform2PatternProperties();
        }

        ITransform2PatternInformation IPatternWithInformation<ITransform2PatternInformation>.Cached => Cached;

        ITransform2PatternInformation IPatternWithInformation<ITransform2PatternInformation>.Current => Current;

        public new ITransform2PatternProperties Properties { get; }

         ITransformPatternProperties ITransformPattern.Properties => Properties;

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

    public class Transform2PatternInformation : TransformPatternInformation, ITransform2PatternInformation
    {
        public Transform2PatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool CanZoom => Get<bool>(Transform2PatternIds.CanZoomProperty);

        public double ZoomLevel => Get<double>(Transform2PatternIds.ZoomLevelProperty);

        public double ZoomMaximum => Get<double>(Transform2PatternIds.ZoomMaximumProperty);

        public double ZoomMinimum => Get<double>(Transform2PatternIds.ZoomMinimumProperty);
    }
}
