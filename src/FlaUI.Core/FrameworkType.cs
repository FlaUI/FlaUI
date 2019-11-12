namespace FlaUI.Core
{
    /// <summary>
    /// An enum for the known framework types.
    /// </summary>
    public enum FrameworkType
    {
        /// <summary>
        /// No framework is used.
        /// </summary>
        None,

        /// <summary>
        /// The framework used is unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// The framework used is WPF.
        /// </summary>
        Wpf,

        /// <summary>
        /// The framework used is Windows Forms.
        /// </summary>
        WinForms,

        /// <summary>
        /// The framework used is Win32.
        /// </summary>
        Win32,

        /// <summary>
        /// The framework used is XAML (Universal Application).
        /// </summary>
        Xaml
    }
}
