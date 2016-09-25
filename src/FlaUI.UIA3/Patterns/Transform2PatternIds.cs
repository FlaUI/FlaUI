using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public static class Transform2PatternIds
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPattern2Id, "Transform2");
        public static readonly PropertyId CanZoomProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2CanZoomPropertyId, "CanZoom");
        public static readonly PropertyId ZoomLevelProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId, "ZoomLevel");
        public static readonly PropertyId ZoomMaximumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId, "ZoomMaximum");
        public static readonly PropertyId ZoomMinimumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId, "ZoomMinimum");
    }

    public class Transform2PatternProperties : TransformPatternProperties, ITransform2PatternProperties
    {
        public PropertyId CanZoomProperty
        {
            get { return Transform2PatternIds.CanZoomProperty; }
        }

        public PropertyId ZoomLevelProperty
        {
            get { return Transform2PatternIds.ZoomLevelProperty; }
        }

        public PropertyId ZoomMaximumProperty
        {
            get { return Transform2PatternIds.ZoomMaximumProperty; }
        }

        public PropertyId ZoomMinimumProperty
        {
            get {return Transform2PatternIds.ZoomMinimumProperty; }
        }
    }
}
