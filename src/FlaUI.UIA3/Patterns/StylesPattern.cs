using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class StylesPattern : PatternBase<UIA.IUIAutomationStylesPattern>, IStylesPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_StylesPatternId, "Styles", AutomationObjectIds.IsStylesPatternAvailableProperty);
        public static readonly PropertyId ExtendedPropertiesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesExtendedPropertiesPropertyId, "ExtendedProperties");
        public static readonly PropertyId FillColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillColorPropertyId, "FillColor");
        public static readonly PropertyId FillPatternColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillPatternColorPropertyId, "FillPatternColor");
        public static readonly PropertyId FillPatternStyleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesFillPatternStylePropertyId, "FillPatternStyle");
        public static readonly PropertyId ShapeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesShapePropertyId, "Shape");
        public static readonly PropertyId StyleIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesStyleIdPropertyId, "StyleId").SetConverter(StyleTypeConverter.ToStyleType);
        public static readonly PropertyId StyleNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_StylesStyleNamePropertyId, "StyleName");

        public StylesPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationStylesPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IStylesPatternProperties Properties => Automation.PropertyLibrary.Styles;

        public string ExtendedProperties => Get<string>(ExtendedPropertiesProperty);

        public int FillColor => Get<int>(FillColorProperty);

        public int FillPatternColor => Get<int>(FillPatternColorProperty);

        public string FillPatternStyle => Get<string>(FillPatternStyleProperty);

        public string Shape => Get<string>(ShapeProperty);

        public StyleType Style => Get<StyleType>(StyleIdProperty);

        public string StyleName => Get<string>(StyleNameProperty);

        // TODO: Any way to implement that?
        //public void GetCachedExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
        //public void GetCurrentExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
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
