using System;
using System.Threading;

namespace FlaUI.Core
{
    /// <summary>
    /// An <see cref="IDisposable"/> implementation that executes an <see cref="Action"/> upon disposal.
    /// </summary>
    public class ActionDisposable : IDisposable
    {
        private volatile Action disposeAction;

        /// <summary>
        /// Constructs a new disposable with the given action used for disposal.
        /// </summary>
        /// <param name="disposeAction">The action that is called upon disposal.</param>
        public ActionDisposable(Action disposeAction)
        {
            this.disposeAction = disposeAction;
        }

        /// <summary>
        /// Calls the defined <see cref="Action"/>.
        /// </summary>
        public void Dispose()
        {
            // Set the action to null to make sure it is only called once
            Interlocked.Exchange(ref disposeAction, null)?.Invoke();
        }
    }
}
