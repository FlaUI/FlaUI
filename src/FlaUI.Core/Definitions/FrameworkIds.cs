namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Converts a string to a <see cref="FrameworkType"/>.
    /// </summary>
    public static class FrameworkIds
    {
        /// <summary>
        /// Converts a string to a <see cref="FrameworkType"/>
        /// </summary>
        /// <param name="frameworkId">The string to convert.</param>
        /// <returns>The matched <see cref="FrameworkType"/>. Defaults to <see cref="FrameworkType.Unknown"/>.</returns>
        public static FrameworkType ConvertToFrameworkType(string frameworkId)
        {
            switch (frameworkId)
            {
                case "":
                    return FrameworkType.None;
                case "WPF":
                    return FrameworkType.Wpf;
                case "WinForm":
                    return FrameworkType.WinForms;
                case "Win32":
                    return FrameworkType.Win32;
                case "XAML":
                    // Universal app
                    return FrameworkType.Xaml;
                default:
                    return FrameworkType.Unknown;
            }
        }
    }
}
