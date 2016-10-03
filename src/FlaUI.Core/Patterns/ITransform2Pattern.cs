using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITransform2Pattern : IPatternWithInformation<ITransform2PatternInformation>, ITransformPattern
    {
        new ITransform2PatternProperties Properties { get; }
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

    public interface ITransform2PatternInformation : ITransformPatternInformation
    {
        bool CanZoom { get; }
        double ZoomLevel { get; }
        double ZoomMaximum { get; }
        double ZoomMinimum { get; }
    }
}
