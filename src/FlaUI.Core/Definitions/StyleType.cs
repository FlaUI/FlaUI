using interop.UIAutomationCore;

namespace FlaUI.Core.Definitions
{
    public enum StyleType
    {
        BulletedList = UIA_StyleIds.StyleId_BulletedList,
        Custom = UIA_StyleIds.StyleId_Custom,
        Emphasis = UIA_StyleIds.StyleId_Emphasis,
        Heading1 = UIA_StyleIds.StyleId_Heading1,
        Heading2 = UIA_StyleIds.StyleId_Heading2,
        Heading3 = UIA_StyleIds.StyleId_Heading3,
        Heading4 = UIA_StyleIds.StyleId_Heading4,
        Heading5 = UIA_StyleIds.StyleId_Heading5,
        Heading6 = UIA_StyleIds.StyleId_Heading6,
        Heading7 = UIA_StyleIds.StyleId_Heading7,
        Heading8 = UIA_StyleIds.StyleId_Heading8,
        Heading9 = UIA_StyleIds.StyleId_Heading9,
        Normal = UIA_StyleIds.StyleId_Normal,
        NumberedList = UIA_StyleIds.StyleId_NumberedList,
        Quote = UIA_StyleIds.StyleId_Quote,
        Subtitle = UIA_StyleIds.StyleId_Subtitle,
        Title = UIA_StyleIds.StyleId_Title,
    }
}
