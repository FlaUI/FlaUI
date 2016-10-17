using System.Globalization;

namespace FlaUI.Core.Tools
{
    public static class SystemLanguageRetreiver
    {
        public static CultureInfo GetCurrentOsCulture()
        {
            var currentOsCulture = CultureInfo.InstalledUICulture;
            return currentOsCulture;
        }
    }
}
