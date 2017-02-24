using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IRangeValuePattern : IPattern
    {
        IRangeValuePatternProperties Properties { get; }
        bool IsReadOnly { get; }
        double LargeChange { get; }
        double Maximum { get; }
        double Minimum { get; }
        double SmallChange { get; }
        double Value { get; }
        void SetValue(double val);
    }

    public interface IRangeValuePatternProperties
    {
        PropertyId IsReadOnlyProperty { get; }
        PropertyId LargeChangeProperty { get; }
        PropertyId MaximumProperty { get; }
        PropertyId MinimumProperty { get; }
        PropertyId SmallChangeProperty { get; }
        PropertyId ValueProperty { get; }
    }
}
