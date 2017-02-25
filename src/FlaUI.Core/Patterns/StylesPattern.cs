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
        PropertyId ExtendedPropertiesProperty { get; }
        PropertyId FillColorProperty { get; }
        PropertyId FillPatternColorProperty { get; }
        PropertyId FillPatternStyleProperty { get; }
        PropertyId ShapeProperty { get; }
        PropertyId StyleIdProperty { get; }
        PropertyId StyleNameProperty { get; }
    }

    public abstract class StylesPatternBase<TNativePattern> : PatternBase<TNativePattern>, IStylesPattern
    {
        protected StylesPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ExtendedProperties = new AutomationProperty<string>(() => Properties.ExtendedPropertiesProperty, BasicAutomationElement);
            FillColor = new AutomationProperty<int>(() => Properties.FillColorProperty, BasicAutomationElement);
            FillPatternColor = new AutomationProperty<int>(() => Properties.FillPatternColorProperty, BasicAutomationElement);
            FillPatternStyle = new AutomationProperty<string>(() => Properties.FillPatternStyleProperty, BasicAutomationElement);
            Shape = new AutomationProperty<string>(() => Properties.ShapeProperty, BasicAutomationElement);
            Style = new AutomationProperty<StyleType>(() => Properties.StyleIdProperty, BasicAutomationElement);
            StyleName = new AutomationProperty<string>(() => Properties.StyleNameProperty, BasicAutomationElement);
        }

        public IStylesPatternProperties Properties => Automation.PropertyLibrary.Styles;

       public AutomationProperty<string> ExtendedProperties { get; }
       public AutomationProperty<int> FillColor { get; }
       public AutomationProperty<int> FillPatternColor { get; }
       public AutomationProperty<string> FillPatternStyle { get; }
       public AutomationProperty<string> Shape { get; }
       public AutomationProperty<StyleType> Style { get; }
       public AutomationProperty<string> StyleName { get; }
    }
}
