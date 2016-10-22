using System;
using FlaUI.Core.Definitions;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Converters
{
    public static class StyleTypeConverter
    {
        public static object ToStyleType(object nativeStyleType)
        {
            switch ((int)nativeStyleType)
            {
                case UIA.UIA_StyleIds.StyleId_BulletedList:
                    return StyleType.BulletedList;
                case UIA.UIA_StyleIds.StyleId_Custom:
                    return StyleType.Custom;
                case UIA.UIA_StyleIds.StyleId_Emphasis:
                    return StyleType.Emphasis;
                case UIA.UIA_StyleIds.StyleId_Heading1:
                    return StyleType.Heading1;
                case UIA.UIA_StyleIds.StyleId_Heading2:
                    return StyleType.Heading2;
                case UIA.UIA_StyleIds.StyleId_Heading3:
                    return StyleType.Heading3;
                case UIA.UIA_StyleIds.StyleId_Heading4:
                    return StyleType.Heading4;
                case UIA.UIA_StyleIds.StyleId_Heading5:
                    return StyleType.Heading5;
                case UIA.UIA_StyleIds.StyleId_Heading6:
                    return StyleType.Heading6;
                case UIA.UIA_StyleIds.StyleId_Heading7:
                    return StyleType.Heading7;
                case UIA.UIA_StyleIds.StyleId_Heading8:
                    return StyleType.Heading8;
                case UIA.UIA_StyleIds.StyleId_Heading9:
                    return StyleType.Heading9;
                case UIA.UIA_StyleIds.StyleId_Normal:
                    return StyleType.Normal;
                case UIA.UIA_StyleIds.StyleId_NumberedList:
                    return StyleType.NumberedList;
                case UIA.UIA_StyleIds.StyleId_Quote:
                    return StyleType.Quote;
                case UIA.UIA_StyleIds.StyleId_Subtitle:
                    return StyleType.Subtitle;
                case UIA.UIA_StyleIds.StyleId_Title:
                    return StyleType.Title;
                default:
                    throw new NotSupportedException();
            }
        }

        public static object ToStyleTypeNative(StyleType styleType)
        {
            switch (styleType)
            {
                case StyleType.BulletedList:
                    return UIA.UIA_StyleIds.StyleId_BulletedList;
                case StyleType.Custom:
                    return UIA.UIA_StyleIds.StyleId_Custom;
                case StyleType.Emphasis:
                    return UIA.UIA_StyleIds.StyleId_Emphasis;
                case StyleType.Heading1:
                    return UIA.UIA_StyleIds.StyleId_Heading1;
                case StyleType.Heading2:
                    return UIA.UIA_StyleIds.StyleId_Heading2;
                case StyleType.Heading3:
                    return UIA.UIA_StyleIds.StyleId_Heading3;
                case StyleType.Heading4:
                    return UIA.UIA_StyleIds.StyleId_Heading4;
                case StyleType.Heading5:
                    return UIA.UIA_StyleIds.StyleId_Heading5;
                case StyleType.Heading6:
                    return UIA.UIA_StyleIds.StyleId_Heading6;
                case StyleType.Heading7:
                    return UIA.UIA_StyleIds.StyleId_Heading7;
                case StyleType.Heading8:
                    return UIA.UIA_StyleIds.StyleId_Heading8;
                case StyleType.Heading9:
                    return UIA.UIA_StyleIds.StyleId_Heading9;
                case StyleType.Normal:
                    return UIA.UIA_StyleIds.StyleId_Normal;
                case StyleType.NumberedList:
                    return UIA.UIA_StyleIds.StyleId_NumberedList;
                case StyleType.Quote:
                    return UIA.UIA_StyleIds.StyleId_Quote;
                case StyleType.Subtitle:
                    return UIA.UIA_StyleIds.StyleId_Subtitle;
                case StyleType.Title:
                    return UIA.UIA_StyleIds.StyleId_Title;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
