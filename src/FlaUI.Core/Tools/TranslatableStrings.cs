namespace FlaUI.Core.Tools
{
    public static class TranslatableStrings
    {
        static TranslatableStrings()
        {
            switch (SystemLanguageRetreiver.GetCurrentOsCulture().TwoLetterISOLanguageName)
            {
                case "de":
                    HorizontalScrollBar = "Horizontale Schiebeleiste";
                    VerticalScrollBar = "Vertikale Schiebeleiste";
                    TableHorizontalScrollBar = "Horizontale Schiebeleiste";
                    TableVerticalScrollBar = "Vertikale Schiebeleiste";
                    break;
                default:
                    HorizontalScrollBar = "Horizontal ScrollBar";
                    VerticalScrollBar = "Vertical ScrollBar";
                    TableHorizontalScrollBar = "Horizontal Scroll Bar";
                    TableVerticalScrollBar = "Vertical Scroll Bar";
                    break;
            }
        }

        public static string HorizontalScrollBar { get; }
        public static string VerticalScrollBar { get; }
        public static string TableHorizontalScrollBar { get; }
        public static string TableVerticalScrollBar { get; }
    }
}
