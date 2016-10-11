namespace FlaUI.Core.Definitions
{
    public static class FrameworkIds
    {
        public static readonly string Wpf = "WPF";
        public static readonly string WinForms = "WinForm";
        public static readonly string Win32 = "Win32";

        public static FrameworkType ConvertToFrameworkType(string frameworkId)
        {
            if (frameworkId == Wpf)
            {
                return FrameworkType.Wpf;
            }
            if (frameworkId == WinForms)
            {
                return FrameworkType.WinForms;
            }
            if (frameworkId == Win32)
            {
                return FrameworkType.Win32;
            }
            return FrameworkType.Unknown;
        }
    }
}
