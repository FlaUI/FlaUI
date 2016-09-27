namespace FlaUI.Core.Definitions
{
    public static class FrameworkIds
    {
        public static readonly string Wpf = "WPF";
        public static readonly string WinForms = "WinForm";

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
            return FrameworkType.Unknown;
        }
    }
}