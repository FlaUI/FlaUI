namespace FlaUI.Core.Patterns.Infrastructure
{
    public abstract class PatternBaseWithInformation<TNativePattern, TInfo> : PatternBase<TNativePattern>, IPatternWithInformation<TInfo> where TInfo : IPatternInformation
    {
        protected PatternBaseWithInformation(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
            // ReSharper disable VirtualMemberCallInConstructor
            Cached = CreateInformation();
            Current = CreateInformation();
            // ReSharper restore VirtualMemberCallInConstructor
        }

        public TInfo Cached { get; }
        public TInfo Current { get; }

        protected abstract TInfo CreateInformation();
    }
}
