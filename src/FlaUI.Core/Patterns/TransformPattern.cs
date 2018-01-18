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
        PropertyId CanMove { get; }
        PropertyId CanResize { get; }
        PropertyId CanRotate { get; }
    }

    public abstract class TransformPatternBase<TNativePattern> : PatternBase<TNativePattern>, ITransformPattern
        where TNativePattern : class
    {
        private AutomationProperty<bool> _canMove;
        private AutomationProperty<bool> _canResize;
        private AutomationProperty<bool> _canRotate;

        protected TransformPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ITransformPatternProperties Properties => Automation.PropertyLibrary.Transform;

        public AutomationProperty<bool> CanMove => GetOrCreate(ref _canMove, Properties.CanMove);
        public AutomationProperty<bool> CanResize => GetOrCreate(ref _canResize, Properties.CanResize);
        public AutomationProperty<bool> CanRotate => GetOrCreate(ref _canRotate, Properties.CanRotate);

        public abstract void Move(double x, double y);
        public abstract void Resize(double width, double height);
        public abstract void Rotate(double degrees);
    }
}
