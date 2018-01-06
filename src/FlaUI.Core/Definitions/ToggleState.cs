using FlaUI.Core.Patterns;

namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the toggle state of a Microsoft UI Automation element that implements the <see cref="ITogglePattern"/>.
    /// </summary>
    public enum ToggleState
    {
        /// <summary>
        /// The UI Automation element is not selected, checked, marked or otherwise activated.
        /// </summary>
        Off = 0,

        /// <summary>
        /// The UI Automation element is selected, checked, marked or otherwise activated.
        /// </summary>
        On = 1,

        /// <summary>
        /// The UI Automation element is in an indeterminate state.
        /// </summary>
        Indeterminate = 2
    }
}
