using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class StylesPattern : PatternBaseWithInformation<UIA.IUIAutomationStylesPattern, StylesPatternInformation>, IStylesPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_StylesPatternId, "Styles");
        public static readonly PropertyId ExtendedPropertiesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesExtendedPropertiesPropertyId, "ExtendedProperties");
        public static readonly PropertyId FillColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillColorPropertyId, "FillColor");
        public static readonly PropertyId FillPatternColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillPatternColorPropertyId, "FillPatternColor");
        public static readonly PropertyId FillPatternStyleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillPatternStylePropertyId, "FillPatternStyle");
        public static readonly PropertyId ShapeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesShapePropertyId, "Shape");
        public static readonly PropertyId StyleIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesStyleIdPropertyId, "StyleId").SetConverter(NativeValueConverter.ToStyleType);
        public static readonly PropertyId StyleNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesStyleNamePropertyId, "StyleName");

        public StylesPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationStylesPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new StylesPatternProperties();
        }

        IStylesPatternInformation IPatternWithInformation<IStylesPatternInformation>.Cached => Cached;

        IStylesPatternInformation IPatternWithInformation<IStylesPatternInformation>.Current => Current;

        public IStylesPatternProperties Properties { get; }

        protected override StylesPatternInformation CreateInformation(bool cached)
        {
            return new StylesPatternInformation(BasicAutomationElement, cached);
        }

        // TODO: Any way to implement that?
        //public void GetCachedExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
        //public void GetCurrentExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
    }

    public class StylesPatternInformation : InformationBase, IStylesPatternInformation
    {
        public StylesPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public string ExtendedProperties => Get<string>(StylesPattern.ExtendedPropertiesProperty);

        public int FillColor => Get<int>(StylesPattern.FillColorProperty);

        public int FillPatternColor => Get<int>(StylesPattern.FillPatternColorProperty);

        public string FillPatternStyle => Get<string>(StylesPattern.FillPatternStyleProperty);

        public string Shape => Get<string>(StylesPattern.ShapeProperty);

        public StyleType Style => Get<StyleType>(StylesPattern.StyleIdProperty);

        public string StyleName => Get<string>(StylesPattern.StyleNameProperty);
    }

    public class StylesPatternProperties : IStylesPatternProperties
    {
        public PropertyId ExtendedPropertiesProperty => StylesPattern.ExtendedPropertiesProperty;
        public PropertyId FillColorProperty => StylesPattern.FillColorProperty;
        public PropertyId FillPatternColorProperty => StylesPattern.FillPatternColorProperty;
        public PropertyId FillPatternStyleProperty => StylesPattern.FillPatternStyleProperty;
        public PropertyId ShapeProperty => StylesPattern.ShapeProperty;
        public PropertyId StyleIdProperty => StylesPattern.StyleIdProperty;
        public PropertyId StyleNameProperty => StylesPattern.StyleNameProperty;
    }
}
