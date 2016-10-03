using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class Transform2Pattern : TransformPattern<Transform2PatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPattern2Id, "Transform2");
        public static readonly PropertyId CanZoomProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2CanZoomPropertyId, "CanZoom");
        public static readonly PropertyId ZoomLevelProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId, "ZoomLevel");
        public static readonly PropertyId ZoomMaximumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId, "ZoomMaximum");
        public static readonly PropertyId ZoomMinimumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId, "ZoomMinimum");

        public UIA.IUIAutomationTransformPattern2 ExtendedNativePattern { get; private set; }

        public Transform2Pattern(AutomationElement automationAutomationElement, UIA.IUIAutomationTransformPattern2 nativePattern)
            : base(automationAutomationElement, nativePattern, (element, cached) => new Transform2PatternInformation(element, cached))
        {
            ExtendedNativePattern = nativePattern;
        }

        public void Zoom(double zoom)
        {
            ComCallWrapper.Call(() => ExtendedNativePattern.Zoom(zoom));
        }

        public void ZoomByUnit(ZoomUnit zoomUnit)
        {
            ComCallWrapper.Call(() => ExtendedNativePattern.ZoomByUnit((interop.UIAutomationCore.ZoomUnit)zoomUnit));
        }
    }

    public class Transform2PatternInformation : TransformPatternInformation
    {
        public Transform2PatternInformation(AutomationElement automationAutomationElement, bool cached)
            : base(automationAutomationElement, cached)
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
