namespace FlaUI.Core.Patterns
{
    public interface ITransform2PatternInformation : ITransformPatternInformation
    {
       bool CanZoom { get; }

       double ZoomLevel { get; }

       double ZoomMaximum { get; }

       double ZoomMinimum { get; }
    }
}
