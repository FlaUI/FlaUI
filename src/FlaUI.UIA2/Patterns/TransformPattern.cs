using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TransformPattern : PatternBaseWithInformation<UIA.TransformPattern, TransformPatternInformation>, ITransformPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TransformPattern.Pattern.Id, "Transform");
        public static readonly PropertyId CanMoveProperty = PropertyId.Register(AutomationType.UIA2, UIA.TransformPattern.CanMoveProperty.Id, "CanMove");
        public static readonly PropertyId CanResizeProperty = PropertyId.Register(AutomationType.UIA2, UIA.TransformPattern.CanResizeProperty.Id, "CanResize");
        public static readonly PropertyId CanRotateProperty = PropertyId.Register(AutomationType.UIA2, UIA.TransformPattern.CanRotateProperty.Id, "CanRotate");

        public TransformPattern(BasicAutomationElementBase basicAutomationElement, UIA.TransformPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Cached => Cached;

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Current => Current;

        public ITransformPatternProperties Properties => Automation.PropertyLibrary.Transform;

        protected override TransformPatternInformation CreateInformation(bool cached)
        {
            return new TransformPatternInformation(BasicAutomationElement, cached);
        }

        public void Move(double x, double y)
        {
            NativePattern.Move(x, y);
        }

        public void Resize(double width, double height)
        {
            NativePattern.Resize(width, height);
        }

        public void Rotate(double degrees)
        {
            NativePattern.Rotate(degrees);
        }
    }

    public class TransformPatternInformation : InformationBase, ITransformPatternInformation
    {
        public TransformPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public bool CanMove => Get<bool>(TransformPattern.CanMoveProperty);

        public bool CanResize => Get<bool>(TransformPattern.CanResizeProperty);

        public bool CanRotate => Get<bool>(TransformPattern.CanRotateProperty);
    }

    public class TransformPatternProperties : ITransformPatternProperties
    {
        public PropertyId CanMoveProperty => TransformPattern.CanMoveProperty;

        public PropertyId CanResizeProperty => TransformPattern.CanResizeProperty;

        public PropertyId CanRotateProperty => TransformPattern.CanRotateProperty;
    }
}
