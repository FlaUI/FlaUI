using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITransformPattern: IPatternWithInformation<ITransformPatternInformation>
    {
       void Move(double x, double y);

       void Resize(double width, double height);

       void Rotate(double degrees);
    }
}
