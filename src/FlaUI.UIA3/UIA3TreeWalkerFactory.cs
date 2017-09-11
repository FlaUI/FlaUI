using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.UIA3.Converters;

namespace FlaUI.UIA3
{
    /// <summary>
    /// Factory to create tree walkers for UIA3.
    /// </summary>
    public class UIA3TreeWalkerFactory : ITreeWalkerFactory
    {
        private readonly UIA3Automation _automation;

        /// <summary>
        /// Creates UIA3 tree walker factory.
        /// </summary>
        public UIA3TreeWalkerFactory(UIA3Automation automation)
        {
            _automation = automation;
        }

        /// <inheritdoc />
        public ITreeWalker GetControlViewWalker()
        {
            var nativeTreeWalker = _automation.NativeAutomation.ControlViewWalker;
            return new UIA3TreeWalker(_automation, nativeTreeWalker);
        }

        /// <inheritdoc />
        public ITreeWalker GetContentViewWalker()
        {
            var nativeTreeWalker = _automation.NativeAutomation.ContentViewWalker;
            return new UIA3TreeWalker(_automation, nativeTreeWalker);
        }

        /// <inheritdoc />
        public ITreeWalker GetRawViewWalker()
        {
            var nativeTreeWalker = _automation.NativeAutomation.RawViewWalker;
            return new UIA3TreeWalker(_automation, nativeTreeWalker);
        }

        /// <inheritdoc />
        public ITreeWalker GetCustomTreeWalker(ConditionBase condition)
        {
            var nativeCondition = ConditionConverter.ToNative(_automation, condition);
            var nativeTreeWalker = _automation.NativeAutomation.CreateTreeWalker(nativeCondition);
            return new UIA3TreeWalker(_automation, nativeTreeWalker);
        }
    }
}
