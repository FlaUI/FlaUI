using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Definitions
{
    public enum StyleType
    {
        BulletedList = UIA.UIA_StyleIds.StyleId_BulletedList,
        Custom = UIA.UIA_StyleIds.StyleId_Custom,
        Emphasis = UIA.UIA_StyleIds.StyleId_Emphasis,
        Heading1 = UIA.UIA_StyleIds.StyleId_Heading1,
        Heading2 = UIA.UIA_StyleIds.StyleId_Heading2,
        Heading3 = UIA.UIA_StyleIds.StyleId_Heading3,
        Heading4 = UIA.UIA_StyleIds.StyleId_Heading4,
        Heading5 = UIA.UIA_StyleIds.StyleId_Heading5,
        Heading6 = UIA.UIA_StyleIds.StyleId_Heading6,
        Heading7 = UIA.UIA_StyleIds.StyleId_Heading7,
        Heading8 = UIA.UIA_StyleIds.StyleId_Heading8,
        Heading9 = UIA.UIA_StyleIds.StyleId_Heading9,
        Normal = UIA.UIA_StyleIds.StyleId_Normal,
        NumberedList = UIA.UIA_StyleIds.StyleId_NumberedList,
        Quote = UIA.UIA_StyleIds.StyleId_Quote,
        Subtitle = UIA.UIA_StyleIds.StyleId_Subtitle,
        Title = UIA.UIA_StyleIds.StyleId_Title
    }
}
