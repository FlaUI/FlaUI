using FlaUI.Core;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class StylesPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_StylesPatternId, "Styles");
        public static readonly PropertyId ExtendedPropertiesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesExtendedPropertiesPropertyId, "ExtendedProperties");
        public static readonly PropertyId FillColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillColorPropertyId, "FillColor");
        public static readonly PropertyId FillPatternColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillPatternColorPropertyId, "FillPatternColor");
        public static readonly PropertyId FillPatternStyleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillPatternStylePropertyId, "FillPatternStyle");
        public static readonly PropertyId ShapeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesShapePropertyId, "Shape");
        public static readonly PropertyId StyleIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesStyleIdPropertyId, "StyleId");
        public static readonly PropertyId StyleNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesStyleNamePropertyId, "StyleName");

        internal StylesPattern(Element automationElement, UIA.IUIAutomationStylesPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationStylesPattern NativePattern
        {
            get { return (UIA.IUIAutomationStylesPattern)base.NativePattern; }
        }

        // TODO: Any way to implement that?
        //public void GetCachedExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
        //public void GetCurrentExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
    }

    public class StylesPatternInformation : InformationBase
    {
        public StylesPatternInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public string ExtendedProperties
        {
            get { return Get<string>(StylesPattern.ExtendedPropertiesProperty); }
        }

        public int FillColor
        {
            get { return Get<int>(StylesPattern.FillColorProperty); }
        }

        public int FillPatternColor
        {
            get { return Get<int>(StylesPattern.FillPatternColorProperty); }
        }

        public string FillPatternStyle
        {
            get { return Get<string>(StylesPattern.FillPatternStyleProperty); }
        }

        public string Shape
        {
            get { return Get<string>(StylesPattern.ShapeProperty); }
        }

        public StyleType Style
        {
            get { return Get<StyleType>(StylesPattern.StyleIdProperty); }
        }

        public string StyleName
        {
            get { return Get<string>(StylesPattern.StyleNameProperty); }
        }
    }
}
