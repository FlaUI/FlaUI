using FlaUI.Core.Conditions;

namespace FlaUI.Core
{
    public interface ITreeWalkerFactory
    {
        ITreeWalker GetControlViewWalker();
        ITreeWalker GetContentViewWalker();
        ITreeWalker GetRawViewWalker();
        ITreeWalker GetCustomTreeWalker(ConditionBase condition);
    }
}
