using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Patterns
{
    public interface ITransform2Pattern : ITransformPattern
    {
        new ITransform2PatternProperties Properties { get; }
        bool CanZoom { get; }
        double ZoomLevel { get; }
        double ZoomMaximum { get; }
        double ZoomMinimum { get; }
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
}
