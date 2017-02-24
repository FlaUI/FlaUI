using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITransformPattern : IPattern
    {
        ITransformPatternProperties Properties { get; }

        AutomationProperty<bool> CanMove { get; }
        AutomationProperty<bool> CanResize { get; }
        AutomationProperty<bool> CanRotate { get; }

        void Move(double x, double y);
        void Resize(double width, double height);
        void Rotate(double degrees);
    }

    public interface ITransformPatternProperties
    {
        PropertyId CanMoveProperty { get; }
        PropertyId CanResizeProperty { get; }
        PropertyId CanRotateProperty { get; }
    }

    public abstract class TransformPatternBase<TNativePattern> : PatternBase<TNativePattern>, ITransformPattern
    {
        protected TransformPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            CanMove = new AutomationProperty<bool>(() => Properties.CanMoveProperty, BasicAutomationElement);
            CanResize = new AutomationProperty<bool>(() => Properties.CanResizeProperty, BasicAutomationElement);
            CanRotate = new AutomationProperty<bool>(() => Properties.CanRotateProperty, BasicAutomationElement);
        }

        public ITransformPatternProperties Properties => Automation.PropertyLibrary.Transform;

        public AutomationProperty<bool> CanMove { get; }
        public AutomationProperty<bool> CanResize { get; }
        public AutomationProperty<bool> CanRotate { get; }

        public abstract void Move(double x, double y);
        public abstract void Resize(double width, double height);
        public abstract void Rotate(double degrees);
    }
}
