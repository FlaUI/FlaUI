using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class Transform2Pattern : TransformPattern, ITransform2Pattern
    {
        public new static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPattern2Id, "Transform2", AutomationObjectIds.IsTransformPattern2AvailableProperty);
        public static readonly PropertyId CanZoomProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2CanZoomPropertyId, "CanZoom");
        public static readonly PropertyId ZoomLevelProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId, "ZoomLevel");
        public static readonly PropertyId ZoomMaximumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId, "ZoomMaximum");
        public static readonly PropertyId ZoomMinimumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId, "ZoomMinimum");

        public Transform2Pattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTransformPattern2 nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ExtendedNativePattern = (UIA.IUIAutomationTransformPattern2)NativePattern;
        }

        public UIA.IUIAutomationTransformPattern2 ExtendedNativePattern { get; }

        ITransform2PatternProperties ITransform2Pattern.Properties => Automation.PropertyLibrary.Transform2;
        
        public bool CanZoom => Get<bool>(CanZoomProperty);

        public double ZoomLevel => Get<double>(ZoomLevelProperty);

        public double ZoomMaximum => Get<double>(ZoomMaximumProperty);

        public double ZoomMinimum => Get<double>(ZoomMinimumProperty);

        public void Zoom(double zoom)
        {
            ComCallWrapper.Call(() => ExtendedNativePattern.Zoom(zoom));
        }

        public void ZoomByUnit(ZoomUnit zoomUnit)
        {
            ComCallWrapper.Call(() => ExtendedNativePattern.ZoomByUnit((UIA.ZoomUnit)zoomUnit));
        }
    }

    public class Transform2PatternProperties : TransformPatternProperties, ITransform2PatternProperties
    {
        public PropertyId CanZoomProperty => Transform2Pattern.CanZoomProperty;

        public PropertyId ZoomLevelProperty => Transform2Pattern.ZoomLevelProperty;

        public PropertyId ZoomMaximumProperty => Transform2Pattern.ZoomMaximumProperty;

        public PropertyId ZoomMinimumProperty => Transform2Pattern.ZoomMinimumProperty;
    }
}
