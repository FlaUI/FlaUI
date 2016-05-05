using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class Transform2Pattern : TransformPattern<Transform2PatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TransformPattern2Id, "Transform2");
        public static readonly PropertyId CanZoomProperty = PropertyId.Register(UIA_PropertyIds.UIA_Transform2CanZoomPropertyId, "CanZoom");
        public static readonly PropertyId ZoomLevelProperty = PropertyId.Register(UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId, "ZoomLevel");
        public static readonly PropertyId ZoomMaximumProperty = PropertyId.Register(UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId, "ZoomMaximum");
        public static readonly PropertyId ZoomMinimumProperty = PropertyId.Register(UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId, "ZoomMinimum");

        public IUIAutomationTransformPattern2 ExtendedNativePattern { get; private set; }

        public Transform2Pattern(AutomationElement automationElement, IUIAutomationTransformPattern2 nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new Transform2PatternInformation(element, cached))
        {
            ExtendedNativePattern = nativePattern;
        }

        public void Zoom(double zoom)
        {
            ComCallWrapper.Call(() => ExtendedNativePattern.Zoom(zoom));
        }

        public void ZoomByUnit(Definitions.ZoomUnit zoomUnit)
        {
            ComCallWrapper.Call(() => ExtendedNativePattern.ZoomByUnit((ZoomUnit)zoomUnit));
        }
    }

    public class Transform2PatternInformation : TransformPatternInformation
    {
        public Transform2PatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public bool CanZoom
        {
            get { return Get<bool>(Transform2Pattern.CanZoomProperty); }
        }

        public double ZoomLevel
        {
            get { return Get<double>(Transform2Pattern.ZoomLevelProperty); }
        }

        public double ZoomMaximum
        {
            get { return Get<double>(Transform2Pattern.ZoomMaximumProperty); }
        }

        public double ZoomMinimum
        {
            get { return Get<double>(Transform2Pattern.ZoomMinimumProperty); }
        }
    }
}
