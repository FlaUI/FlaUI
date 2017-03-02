using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Patterns
{
    public interface ITransform2Pattern : ITransformPattern
    {
        new ITransform2PatternProperties Properties { get; }

        AutomationProperty<bool> CanZoom { get; }
        AutomationProperty<double> ZoomLevel { get; }
        AutomationProperty<double> ZoomMaximum { get; }
        AutomationProperty<double> ZoomMinimum { get; }

        void Zoom(double zoom);
        void ZoomByUnit(ZoomUnit zoomUnit);
    }

    public interface ITransform2PatternProperties : ITransformPatternProperties
    {
        PropertyId CanZoom { get; }
        PropertyId ZoomLevel { get; }
        PropertyId ZoomMaximum { get; }
        PropertyId ZoomMinimum { get; }
    }

    public abstract class Transform2PatternBase<TNativePattern> : TransformPatternBase<TNativePattern>, ITransform2Pattern
    {
        private AutomationProperty<bool> _canZoom;
        private AutomationProperty<double> _zoomLevel;
        private AutomationProperty<double> _zoomMaximum;
        private AutomationProperty<double> _zoomMinimum;

        protected Transform2PatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ITransform2PatternProperties ITransform2Pattern.Properties => Automation.PropertyLibrary.Transform2;

        public AutomationProperty<bool> CanZoom => GetOrCreate(ref _canZoom, ((ITransform2Pattern)this).Properties.CanZoom);
        public AutomationProperty<double> ZoomLevel => GetOrCreate(ref _zoomLevel, ((ITransform2Pattern)this).Properties.ZoomLevel);
        public AutomationProperty<double> ZoomMaximum => GetOrCreate(ref _zoomMaximum, ((ITransform2Pattern)this).Properties.ZoomMaximum);
        public AutomationProperty<double> ZoomMinimum => GetOrCreate(ref _zoomMinimum, ((ITransform2Pattern)this).Properties.ZoomMinimum);

        public abstract void Zoom(double zoom);
        public abstract void ZoomByUnit(ZoomUnit zoomUnit);
    }
}
