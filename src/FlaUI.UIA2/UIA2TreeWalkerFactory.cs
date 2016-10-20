using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.UIA2.Converters;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2TreeWalkerFactory : ITreeWalkerFactory
    {
        private readonly UIA2Automation _automation;

        public UIA2TreeWalkerFactory(UIA2Automation automation)
        {
            _automation = automation;
        }

        public ITreeWalker GetControlViewWalker()
        {
            var nativeTreeWalker = UIA.TreeWalker.ControlViewWalker;
            return new UIA2TreeWalker(_automation, nativeTreeWalker);
        }

        public ITreeWalker GetContentViewWalker()
        {
            var nativeTreeWalker = UIA.TreeWalker.ContentViewWalker;
            return new UIA2TreeWalker(_automation, nativeTreeWalker);
        }

        public ITreeWalker GetRawViewWalker()
        {
            var nativeTreeWalker = UIA.TreeWalker.RawViewWalker;
            return new UIA2TreeWalker(_automation, nativeTreeWalker);
        }

        public ITreeWalker GetCustomTreeWalker(ConditionBase condition)
        {
            var nativeCondition = ConditionConverter.ToNative(condition);
            var nativeTreeWalker = new UIA.TreeWalker(nativeCondition);
            return new UIA2TreeWalker(_automation, nativeTreeWalker);
        }
    }
}
