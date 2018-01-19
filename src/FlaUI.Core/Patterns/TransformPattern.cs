using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITransformPattern : IPattern
    {
        ITransformPatternPropertyIds PropertyIds { get; }

        AutomationProperty<bool> CanMove { get; }
        AutomationProperty<bool> CanResize { get; }
        AutomationProperty<bool> CanRotate { get; }

        void Move(double x, double y);
        void Resize(double width, double height);
        void Rotate(double degrees);
    }

    public interface ITransformPatternPropertyIds
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

        public ITransformPatternPropertyIds PropertyIds => Automation.PropertyLibrary.Transform;

        public AutomationProperty<bool> CanMove => GetOrCreate(ref _canMove, PropertyIds.CanMove);
        public AutomationProperty<bool> CanResize => GetOrCreate(ref _canResize, PropertyIds.CanResize);
        public AutomationProperty<bool> CanRotate => GetOrCreate(ref _canRotate, PropertyIds.CanRotate);

        public abstract void Move(double x, double y);
        public abstract void Resize(double width, double height);
        public abstract void Rotate(double degrees);
    }
}
