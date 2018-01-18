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
        where TNativePattern : class
    {
        private AutomationProperty<string> _formula;
        private AutomationProperty<AutomationElement[]> _annotationObjects;
        private AutomationProperty<AnnotationType[]> _annotationTypes;

        protected SpreadsheetItemPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ISpreadsheetItemPatternProperties Properties => Automation.PropertyLibrary.SpreadsheetItem;

        public AutomationProperty<string> Formula => GetOrCreate(ref _formula, Properties.Formula);
        public AutomationProperty<AutomationElement[]> AnnotationObjects => GetOrCreate(ref _annotationObjects, Properties.AnnotationObjects);
        public AutomationProperty<AnnotationType[]> AnnotationTypes => GetOrCreate(ref _annotationTypes, Properties.AnnotationTypes);
    }
}
