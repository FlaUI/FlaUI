using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TransformPattern : TransformPatternBase<UIA.TransformPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TransformPattern.Pattern.Id, "Transform", AutomationObjectIds.IsTransformPatternAvailableProperty);
        public static readonly PropertyId CanMoveProperty = PropertyId.Register(AutomationType.UIA2, UIA.TransformPattern.CanMoveProperty.Id, "CanMove");
        public static readonly PropertyId CanResizeProperty = PropertyId.Register(AutomationType.UIA2, UIA.TransformPattern.CanResizeProperty.Id, "CanResize");
        public static readonly PropertyId CanRotateProperty = PropertyId.Register(AutomationType.UIA2, UIA.TransformPattern.CanRotateProperty.Id, "CanRotate");

        public TransformPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.TransformPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }
        
        public override void Move(double x, double y)
        {
            NativePattern.Move(x, y);
        }

        public override void Resize(double width, double height)
        {
            NativePattern.Resize(width, height);
        }

        public override void Rotate(double degrees)
        {
            NativePattern.Rotate(degrees);
        }
    }

    public class TransformPatternPropertyIds : ITransformPatternPropertyIds
    {
        public PropertyId CanMove => TransformPattern.CanMoveProperty;

        public PropertyId CanResize => TransformPattern.CanResizeProperty;

        public PropertyId CanRotate => TransformPattern.CanRotateProperty;
    }
}
