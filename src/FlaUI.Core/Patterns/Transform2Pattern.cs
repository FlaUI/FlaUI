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
        PropertyId CanZoomProperty { get; }
        PropertyId ZoomLevelProperty { get; }
        PropertyId ZoomMaximumProperty { get; }
        PropertyId ZoomMinimumProperty { get; }
    }

    public abstract class Transform2PatternBase<TNativePattern> : TransformPatternBase<TNativePattern>, ITransform2Pattern
    {
        protected Transform2PatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            CanZoom = new AutomationProperty<bool>(() => ((ITransform2Pattern)this).Properties.CanZoomProperty, BasicAutomationElement);
            ZoomLevel = new AutomationProperty<double>(() => ((ITransform2Pattern)this).Properties.ZoomLevelProperty, BasicAutomationElement);
            ZoomMaximum = new AutomationProperty<double>(() => ((ITransform2Pattern)this).Properties.ZoomMaximumProperty, BasicAutomationElement);
            ZoomMinimum = new AutomationProperty<double>(() => ((ITransform2Pattern)this).Properties.ZoomMinimumProperty, BasicAutomationElement);
        }

        ITransform2PatternProperties ITransform2Pattern.Properties => Automation.PropertyLibrary.Transform2;

        public AutomationProperty<bool> CanZoom { get; }
        public AutomationProperty<double> ZoomLevel { get; }
        public AutomationProperty<double> ZoomMaximum { get; }
        public AutomationProperty<double> ZoomMinimum { get; }

        public abstract void Zoom(double zoom);
        public abstract void ZoomByUnit(ZoomUnit zoomUnit);
    }
}
