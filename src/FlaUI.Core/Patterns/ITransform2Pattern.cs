using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITransform2Pattern : IPatternWithInformation<ITransform2PatternInformation>, ITransformPattern
    {
        void Zoom(double zoom);

        void ZoomByUnit(ZoomUnit zoomUnit);
    }
}
