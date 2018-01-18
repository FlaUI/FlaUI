using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IStylesPattern : IPattern
    {
        IStylesPatternProperties Properties { get; }

         AutomationProperty<string> ExtendedProperties { get; }
         AutomationProperty<int> FillColor { get; }
         AutomationProperty<int> FillPatternColor { get; }
         AutomationProperty<string> FillPatternStyle { get; }
         AutomationProperty<string> Shape { get; }
         AutomationProperty<StyleType> Style { get; }
         AutomationProperty<string> StyleName { get; }
    }

    public interface IStylesPatternProperties
    {
        PropertyId ExtendedProperties { get; }
        PropertyId FillColor { get; }
        PropertyId FillPatternColor { get; }
        PropertyId FillPatternStyle { get; }
        PropertyId Shape { get; }
        PropertyId StyleId { get; }
        PropertyId StyleName { get; }
    }

    public abstract class StylesPatternBase<TNativePattern> : PatternBase<TNativePattern>, IStylesPattern
        where TNativePattern : class
    {
        private AutomationProperty<string> _extendedProperties;
        private AutomationProperty<int> _fillColor;
        private AutomationProperty<int> _fillPatternColor;
        private AutomationProperty<string> _fillPatternStyle;
        private AutomationProperty<string> _shape;
        private AutomationProperty<StyleType> _style;
        private AutomationProperty<string> _styleName;

        protected StylesPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public IStylesPatternProperties Properties => Automation.PropertyLibrary.Styles;

        public AutomationProperty<string> ExtendedProperties => GetOrCreate(ref _extendedProperties, Properties.ExtendedProperties);
        public AutomationProperty<int> FillColor => GetOrCreate(ref _fillColor, Properties.FillColor);
        public AutomationProperty<int> FillPatternColor => GetOrCreate(ref _fillPatternColor, Properties.FillPatternColor);
        public AutomationProperty<string> FillPatternStyle => GetOrCreate(ref _fillPatternStyle, Properties.FillPatternStyle);
        public AutomationProperty<string> Shape => GetOrCreate(ref _shape, Properties.Shape);
        public AutomationProperty<StyleType> Style => GetOrCreate(ref _style, Properties.StyleId);
        public AutomationProperty<string> StyleName => GetOrCreate(ref _styleName, Properties.StyleName);
    }
}
