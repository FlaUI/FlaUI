using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISpreadsheetItemPattern : IPattern
    {
        ISpreadsheetItemPatternProperties Properties { get; }

        AutomationProperty<string> Formula { get; }
        AutomationProperty<AutomationElement[]> AnnotationObjects { get; }
        AutomationProperty<AnnotationType[]> AnnotationTypes { get; }
    }

    public interface ISpreadsheetItemPatternProperties
    {
        PropertyId Formula { get; }
        PropertyId AnnotationObjects { get; }
        PropertyId AnnotationTypes { get; }
    }

    public abstract class SpreadsheetItemPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISpreadsheetItemPattern
    {
        protected SpreadsheetItemPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Formula = new AutomationProperty<string>(() => Properties.Formula, BasicAutomationElement);
            AnnotationObjects = new AutomationProperty<AutomationElement[]>(() => Properties.AnnotationObjects, BasicAutomationElement);
            AnnotationTypes = new AutomationProperty<AnnotationType[]>(() => Properties.AnnotationTypes, BasicAutomationElement);
        }

        public ISpreadsheetItemPatternProperties Properties => Automation.PropertyLibrary.SpreadsheetItem;

        public AutomationProperty<string> Formula { get; }
        public AutomationProperty<AutomationElement[]> AnnotationObjects { get; }
        public AutomationProperty<AnnotationType[]> AnnotationTypes { get; }
    }
}
