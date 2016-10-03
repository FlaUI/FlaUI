namespace FlaUI.Core.Patterns.Infrastructure
{
    public interface IPatternWithInformation<TInfo> : IPattern where TInfo : IPatternInformation
    {
        TInfo Cached { get; }
        TInfo Current { get; }
    }
}
