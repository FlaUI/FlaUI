namespace FlaUI.Core.Definitions
{
    public static class FrameworkIds
    {
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
