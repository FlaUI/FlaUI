namespace FlaUI.Core.Patterns.Infrastructure
{
    public abstract class PatternBaseWithInformation<TNativePattern, TInfo> : PatternBase<TNativePattern>, IPatternWithInformation<TInfo> where TInfo : IPatternInformation
    {
        protected PatternBaseWithInformation(AutomationObjectBase automationObject, TNativePattern nativePattern)
            : base(automationObject, nativePattern)
        {
            // ReSharper disable VirtualMemberCallInConstructor
            Cached = CreateInformation(true);
            Current = CreateInformation(false);
            // ReSharper restore VirtualMemberCallInConstructor
        }

        public TInfo Cached { get; }
        public TInfo Current { get; }

        protected abstract TInfo CreateInformation(bool cached);
    }
}
