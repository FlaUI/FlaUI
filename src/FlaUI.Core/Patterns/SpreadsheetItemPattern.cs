using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISpreadsheetItemPattern : IPattern
    {
        ISpreadsheetItemPatternPropertyIds PropertyIds { get; }

        AutomationProperty<string> Formula { get; }
        AutomationProperty<AutomationElement[]> AnnotationObjects { get; }
        AutomationProperty<AnnotationType[]> AnnotationTypes { get; }
    }

    public interface ISpreadsheetItemPatternPropertyIds
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

        public ISpreadsheetItemPatternPropertyIds PropertyIds => Automation.PropertyLibrary.SpreadsheetItem;

        public AutomationProperty<string> Formula => GetOrCreate(ref _formula, PropertyIds.Formula);
        public AutomationProperty<AutomationElement[]> AnnotationObjects => GetOrCreate(ref _annotationObjects, PropertyIds.AnnotationObjects);
        public AutomationProperty<AnnotationType[]> AnnotationTypes => GetOrCreate(ref _annotationTypes, PropertyIds.AnnotationTypes);
    }
}
