using FlaUI.Core.Conditions;

namespace FlaUI.Core
{
    /// <summary>
    /// Interface for a class to create <see cref="ITreeWalker"/> instances.
    /// </summary>
    public interface ITreeWalkerFactory
    {
        /// <summary>
        /// Creates a control view walker.
        /// </summary>
        ITreeWalker GetControlViewWalker();

        /// <summary>
        /// Creates a content view walker.
        /// </summary>
        ITreeWalker GetContentViewWalker();

        /// <summary>
        /// Creates a raw view walker.
        /// </summary>
        /// <returns></returns>
        ITreeWalker GetRawViewWalker();

        /// <summary>
        /// Creates a custom walker with a given condition.
        /// </summary>
        /// <param name="condition">The condition used for the walker.</param>
        ITreeWalker GetCustomTreeWalker(ConditionBase condition);
    }
}
