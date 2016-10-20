using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.UIA3.Converters;

namespace FlaUI.UIA3
{
    public class UIA3TreeWalkerFactory : ITreeWalkerFactory
    {
        private readonly UIA3Automation _automation;

        public UIA3TreeWalkerFactory(UIA3Automation automation)
        {
            _automation = automation;
        }

        public ITreeWalker GetControlViewWalker()
        {
            var nativeTreeWalker = _automation.NativeAutomation.ControlViewWalker;
            return new UIA3TreeWalker(_automation, nativeTreeWalker);
        }

        public ITreeWalker GetContentViewWalker()
        {
            var nativeTreeWalker = _automation.NativeAutomation.ContentViewWalker;
            return new UIA3TreeWalker(_automation, nativeTreeWalker);
        }

        public ITreeWalker GetRawViewWalker()
        {
            var nativeTreeWalker = _automation.NativeAutomation.RawViewWalker;
            return new UIA3TreeWalker(_automation, nativeTreeWalker);
        }

        public ITreeWalker GetCustomTreeWalker(ConditionBase condition)
        {
            var nativeCondition = ConditionConverter.ToNative(_automation, condition);
            var nativeTreeWalker = _automation.NativeAutomation.CreateTreeWalker(nativeCondition);
            return new UIA3TreeWalker(_automation, nativeTreeWalker);
        }
    }
}
