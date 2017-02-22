using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class Transform2Pattern : TransformPatternBase<UIA.IUIAutomationTransformPattern2, Transform2PatternInformation, Transform2PatternProperties>, ITransform2Pattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPattern2Id, "Transform2", AutomationObjectIds.IsTransformPattern2AvailableProperty);
        public static readonly PropertyId CanZoomProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2CanZoomPropertyId, "CanZoom");
        public static readonly PropertyId ZoomLevelProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId, "ZoomLevel");
        public static readonly PropertyId ZoomMaximumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId, "ZoomMaximum");
        public static readonly PropertyId ZoomMinimumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId, "ZoomMinimum");

        public Transform2Pattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTransformPattern2 nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ITransform2PatternInformation IPatternWithInformation<ITransform2PatternInformation>.Cached => Cached;

        ITransform2PatternInformation IPatternWithInformation<ITransform2PatternInformation>.Current => Current;

        ITransform2PatternProperties ITransform2Pattern.Properties => Properties;

        public override Transform2PatternProperties Properties => (Transform2PatternProperties)Automation.PropertyLibrary.Transform2;

        protected override Transform2PatternInformation CreateInformation()
        {
            return new Transform2PatternInformation(BasicAutomationElement);
        }

        public void Zoom(double zoom)
        {
            ComCallWrapper.Call(() => NativePattern.Zoom(zoom));
        }

        public void ZoomByUnit(ZoomUnit zoomUnit)
        {
            ComCallWrapper.Call(() => NativePattern.ZoomByUnit((UIA.ZoomUnit)zoomUnit));
        }
    }

    public class Transform2PatternInformation : TransformPatternInformation, ITransform2PatternInformation
    {
        public Transform2PatternInformation(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public bool CanZoom => Get<bool>(Transform2Pattern.CanZoomProperty);

        public double ZoomLevel => Get<double>(Transform2Pattern.ZoomLevelProperty);

        public double ZoomMaximum => Get<double>(Transform2Pattern.ZoomMaximumProperty);

        public double ZoomMinimum => Get<double>(Transform2Pattern.ZoomMinimumProperty);
    }

    public class Transform2PatternProperties : TransformPatternProperties, ITransform2PatternProperties
    {
        public PropertyId CanZoomProperty => Transform2Pattern.CanZoomProperty;

        public PropertyId ZoomLevelProperty => Transform2Pattern.ZoomLevelProperty;

        public PropertyId ZoomMaximumProperty => Transform2Pattern.ZoomMaximumProperty;

        public PropertyId ZoomMinimumProperty => Transform2Pattern.ZoomMinimumProperty;
    }
}
