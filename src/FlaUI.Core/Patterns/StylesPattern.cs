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
    {
        protected StylesPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ExtendedProperties = new AutomationProperty<string>(() => Properties.ExtendedProperties, BasicAutomationElement);
            FillColor = new AutomationProperty<int>(() => Properties.FillColor, BasicAutomationElement);
            FillPatternColor = new AutomationProperty<int>(() => Properties.FillPatternColor, BasicAutomationElement);
            FillPatternStyle = new AutomationProperty<string>(() => Properties.FillPatternStyle, BasicAutomationElement);
            Shape = new AutomationProperty<string>(() => Properties.Shape, BasicAutomationElement);
            Style = new AutomationProperty<StyleType>(() => Properties.StyleId, BasicAutomationElement);
            StyleName = new AutomationProperty<string>(() => Properties.StyleName, BasicAutomationElement);
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
