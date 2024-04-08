using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Patterns
{
    public interface ITransform2Pattern : ITransformPattern
    {
        new ITransform2PatternPropertyIds PropertyIds { get; }

        AutomationProperty<bool> CanZoom { get; }
        AutomationProperty<double> ZoomLevel { get; }
        AutomationProperty<double> ZoomMaximum { get; }
        AutomationProperty<double> ZoomMinimum { get; }

        void Zoom(double zoom);
        void ZoomByUnit(ZoomUnit zoomUnit);
    }

    public interface ITransform2PatternPropertyIds : ITransformPatternPropertyIds
    {
        PropertyId CanZoom { get; }
        PropertyId ZoomLevel { get; }
        PropertyId ZoomMaximum { get; }
        PropertyId ZoomMinimum { get; }
    }

    public abstract class Transform2PatternBase<TNativePattern> : TransformPatternBase<TNativePattern>, ITransform2Pattern
        where TNativePattern : class
    {
        private AutomationProperty<bool>? _canZoom;
        private AutomationProperty<double>? _zoomLevel;
        private AutomationProperty<double>? _zoomMaximum;
        private AutomationProperty<double>? _zoomMinimum;

        protected Transform2PatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        ITransform2PatternPropertyIds ITransform2Pattern.PropertyIds => Automation.PropertyLibrary.Transform2;

        public AutomationProperty<bool> CanZoom => GetOrCreate(ref _canZoom, ((ITransform2Pattern)this).PropertyIds.CanZoom);
        public AutomationProperty<double> ZoomLevel => GetOrCreate(ref _zoomLevel, ((ITransform2Pattern)this).PropertyIds.ZoomLevel);
        public AutomationProperty<double> ZoomMaximum => GetOrCreate(ref _zoomMaximum, ((ITransform2Pattern)this).PropertyIds.ZoomMaximum);
        public AutomationProperty<double> ZoomMinimum => GetOrCreate(ref _zoomMinimum, ((ITransform2Pattern)this).PropertyIds.ZoomMinimum);

        public abstract void Zoom(double zoom);
        public abstract void ZoomByUnit(ZoomUnit zoomUnit);
    }
}
