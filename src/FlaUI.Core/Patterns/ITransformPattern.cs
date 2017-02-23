using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITransformPattern : IPattern
    {
        ITransformPatternProperties Properties { get; }
        bool CanMove { get; }
        bool CanResize { get; }
        bool CanRotate { get; }
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
}
