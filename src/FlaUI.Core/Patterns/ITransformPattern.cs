using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITransformPattern : IPatternWithInformation<ITransformPatternInformation>
    {
        ITransformPatternProperties Properties { get; }
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

    public interface ITransformPatternInformation : IPatternInformation
    {
        bool CanMove { get; }
        bool CanResize { get; }
        bool CanRotate { get; }
    }
}
